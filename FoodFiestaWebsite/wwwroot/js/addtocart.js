function getFood() {
    const Container = document.getElementById('foodContainer');

// Clear the container before fetching new data
Container.innerHTML = '';

fetch("https://localhost:7097/api/Foods", {
    method: 'GET',
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
return response.json();
        })
        .then(data => {
    console.log(data);

            // Loop through the data and create Bootstrap cards
            data.forEach(food => {
                const card = document.createElement('div');
card.className = 'card mb-4';

card.innerHTML = `
<div class="card-body">
    <h5 class="card-title">${food.foodName}</h5>
    <p class="card-text">Price: $${food.price}</p>
    <button class="btn btn-primary" onclick="addToCart(${food.id})">Add To Cart</button>
</div>
`;

Container.appendChild(card);
            });
        })
        .catch(error => {
    console.error('Fetch error:', error);
        });
}
function getDrinks() {
    const Container = document.getElementById('foodContainer');

// Clear the container before fetching new data
Container.innerHTML = '';

fetch("https://localhost:7097/api/Drink", {
    method: 'GET',
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
return response.json();
        })
        .then(data => {
    console.log(data);

            // Assuming the properties are named appropriately, adjust as needed
            data.forEach(drink => {
                const card = document.createElement('div');
card.className = 'card mb-4';

card.innerHTML = `
<div class="card-body">
    <h5 class="card-title">${drink.name}</h5>
    <p class="card-text">Price: $${drink.price}</p>
    <button class="btn btn-primary" onclick="addToCart(${drink.id})">Add To Cart</button>
</div>
`;

Container.appendChild(card);
            });
        })
        .catch(error => {
    console.error('Fetch error:', error);
        });
}
    
document.addEventListener("DOMContentLoaded", () => {
    const token = localStorage.getItem("jwtToken");
    const Container = document.getElementById('foodContainer');
    Container.innerHTML = '';

    getFood();
});

function addToCart(id) {
    var userId = localStorage.getItem("userId");
    var token = localStorage.getItem("jwtToken");
    var data = {
        id: 0,
        userId: userId,
        foodId: id,
    };
    fetch("https://localhost:7097/api/carts", {
        method: "POST",
        headers: {
            "Authorization": `bearer ${token}`,
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            // Process the data from the API
            console.log(data);
        })
        .catch(error => {
            // Log the error details
            console.error("Fetch error:", error);
        });
}
