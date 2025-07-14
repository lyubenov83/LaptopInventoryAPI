async function loadLaptops() {
  const response = await fetch("https://localhost:52685/api/laptops");

  if (!response.ok) {
    alert("❌ Failed to fetch laptops!");
    return;
  }

  const laptops = await response.json();
  const tableBody = document.querySelector("#laptopTable tbody");
  tableBody.innerHTML = ""; // Изчисти старата информация

  laptops.forEach(laptop => {
    const row = document.createElement("tr");

    row.innerHTML = `
      <td>${laptop.id}</td>
      <td>${laptop.brand}</td>
      <td>${laptop.model}</td>
      <td>${laptop.inStock ? "✅" : "❌"}</td>
      <td>
        <button onclick="deleteLaptop(${laptop.id})">🗑 Delete</button>
      </td>
    `;

    tableBody.appendChild(row);
  });
}

async function deleteLaptop(id) {
  const confirmed = confirm("Наистина ли искаш да изтриеш този лаптоп?");
  if (!confirmed) return;

  const response = await fetch(`https://localhost:52685/api/laptops/${id}`, {
    method: "DELETE"
  });

  if (response.ok) {
    alert("🗑 Лаптопът е изтрит!");
    loadLaptops(); // Презареди таблицата
  } else {
    alert("❌ Грешка при изтриване.");
  }
}
