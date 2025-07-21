const apiBase = "/api/laptops";
const tableBody = document.getElementById("laptopTable");
const messageBox = document.getElementById("message");

let laptopToDeleteId = null;

window.onload = () => fetchLaptops();

document.getElementById("laptopForm").addEventListener("submit", async (e) => {
    e.preventDefault();

    const brand = document.getElementById("brand").value;
    const model = document.getElementById("model").value;
    const unitPrice = parseFloat(document.getElementById("unitPrice").value);
    const quantity = parseInt(document.getElementById("quantity").value);
    const totalPrice = unitPrice * quantity;

    const laptop = { brand, model, unitPrice, quantity, totalPrice };

    const res = await fetch(apiBase, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(laptop)
    });

    if (res.ok) {
        showMessage("Laptop added successfully", "success");
        fetchLaptops();
        e.target.reset();
    } else {
        showMessage("Failed to add laptop", "deleted"); // You can use .deleted here for red, or keep .error if using a separate style
    }
});

async function fetchLaptops() {
    const res = await fetch(apiBase);
    const laptops = await res.json();

    tableBody.innerHTML = "";
    laptops.forEach(laptop => {
        const row = document.createElement("tr");
        row.innerHTML = `
            <td>${laptop.brand}</td>
            <td>${laptop.model}</td>
            <td>$${laptop.unitPrice}</td>
            <td>${laptop.quantity}</td>
            <td>$${laptop.totalPrice}</td>
            <td><button class="delete-btn" onclick="showDeleteModal(${laptop.id})">Delete</button></td>
        `;
        tableBody.appendChild(row);
    });
}


// ✅ Modal logic
function showDeleteModal(id) {
    laptopToDeleteId = id;
    document.getElementById("confirmModal").style.display = "block";
}

document.getElementById("confirmYes").addEventListener("click", async () => {
    if (!laptopToDeleteId) return;
    const res = await fetch(`${apiBase}/${laptopToDeleteId}`, { method: "DELETE" });
    document.getElementById("confirmModal").style.display = "none";
    if (res.ok) {
        showMessage("Laptop deleted", "deleted");
        fetchLaptops();
    } else {
        showMessage("Failed to delete laptop", "deleted");
    }
    laptopToDeleteId = null;
});

document.getElementById("confirmNo").addEventListener("click", () => {
    document.getElementById("confirmModal").style.display = "none";
    laptopToDeleteId = null;
});

function showMessage(msg, type) {
    messageBox.textContent = msg;
    messageBox.className = type;
    setTimeout(() => {
        messageBox.textContent = "";
        messageBox.className = "";
    }, 3000);
}
