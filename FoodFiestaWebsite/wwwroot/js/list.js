function getCartItem(foodId) {
    return fetch(`https://localhost:7097/api/foods/${foodId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .catch(error => {
            // Handle errors (e.g., show an error message to the user)
            console.error('Fetch error:', error);
        });
}

document.addEventListener("DOMContentLoaded", () => {
    var container = document.querySelector(".foodContainer");
    var userId = localStorage.getItem("userId");
    userId = parseInt(userId);

    fetch("https://localhost:7097/api/carts", {
        method: "GET",
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            var cartItemsList = [];

            // Filter data based on userId
            var filteredData = data.filter(item => item.userId === userId);

            // Use Promise.all to wait for all asynchronous getCartItem calls
            var promises = filteredData.map(item => getCartItem(item.foodId));

            Promise.all(promises)
                .then(results => {
                    cartItemsList = results;
                    console.log(cartItemsList);

                    // Clear existing content in the container
                    container.innerHTML = '';

                    // Create card elements for each item in the cartItemsList
                    cartItemsList.forEach(item => {
                        var card = document.createElement("div");
                        card.classList.add("card");

                        var foodName = document.createElement("h2");
                        foodName.textContent = item.foodName;

                        var price = document.createElement("p");
                        price.textContent = `Price: $${item.price.toFixed(2)}`;

                        card.appendChild(foodName);
                        card.appendChild(price);

                        container.appendChild(card);
                    })
                        .catch(error => {
                            console.error('Error fetching cart items:', error);
                        });
                })
                .catch(error => {
                    console.error('Fetch error:', error);
                });
        })
})