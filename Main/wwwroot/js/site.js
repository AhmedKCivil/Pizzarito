document.addEventListener('DOMContentLoaded', function () {
    // Find all add-to-cart buttons
    document.querySelectorAll('.add-to-cart-btn').forEach(button => {
        button.addEventListener('click', event => {
            event.preventDefault();
            const buttonClicked = event.target;
            const form = buttonClicked.closest('form');
            const formData = new FormData(form);

            // Disable the button to prevent multiple clicks
            buttonClicked.disabled = true;
            buttonClicked.textContent = "Adding..."; // Optional: Update button text to indicate the action

            // Send the data to the server to add the item to the cart
            fetch('/Pizzas/Pizzas?handler=AddToCart', {
                method: 'POST',
                body: formData
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`Server error: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    // Update the cart count without needing a page refresh
                    const cartCountElement = document.getElementById("cart-count");
                    if (cartCountElement) {
                        cartCountElement.textContent = data.cartCount;
                    }

                    // Show the green tick and re-enable the button after a delay
                    setTimeout(() => {
                        buttonClicked.disabled = false;
                        buttonClicked.textContent = "Add To Cart"; // Reset the button text

                        // Add green tick icon after the button text
                        const tickIcon = document.createElement('span');
                        tickIcon.classList.add('check-icon');
                        tickIcon.innerHTML = ' &#10004;'; // Green tick symbol (check mark)
                        buttonClicked.appendChild(tickIcon); // Add the green tick to the button
                    }, 1500);
                })
                .catch(error => {
                    console.error('Fetch error:', error);
                    // Re-enable the button if there's an error
                    setTimeout(() => {
                        buttonClicked.disabled = false;
                        buttonClicked.textContent = "Add To Cart"; // Reset button text on error
                    }, 1500);
                });
        });
    });
});

