document.addEventListener("DOMContentLoaded", function () {
    const deleteButton = document.getElementById("deleteButton");
    const confirmationPopUp = document.getElementById("confirmationPopUp");
    const confirmYes = document.getElementById("confirmYes");
    const confirmNo = document.getElementById("confirmNo");
    const deleteForm = document.getElementById("deleteForm");

    // Show confirmation popup when delete button is clicked
    deleteButton.addEventListener("click", function (e) {
        e.preventDefault(); // Prevent the form from submitting immediately
        confirmationPopUp.style.display = "block"; // Show the popup
    });

    // If user confirms deletion, submit the form to delete
    confirmYes.addEventListener("click", function () {
        deleteForm.submit(); // Submit the form
    });

    // If user cancels deletion, hide the popup
    confirmNo.addEventListener("click", function () {
        confirmationPopUp.style.display = "none"; // Hide the popup
    });
});












//document.addEventListener('DOMContentLoaded', function () {
//    const deleteButton = document.getElementById('deleteButton');
//    const confirmationPopUp = document.getElementById('confirmationPopUp');
//    const confirmYes = document.getElementById('confirmYes');
//    const confirmNo = document.getElementById('confirmNo');

//    // Show confirmation popup
//    deleteButton.addEventListener('click', function () {
//        confirmationPopUp.style.display = 'block';
//    });

//    // Handle "Yes" click
//    confirmYes.addEventListener('click', async function () {
//        confirmationPopUp.style.display = 'none';

//        const pizzaId = "@Model.PizzaDetail.Id";

//        if (!pizzaId) {
//            alert('Error: Pizza ID is missing.');
//            return;
//        }

//        try {
//            const response = await fetch(`/Pizzas/Delete/${pizzaId}`, {
//                method: 'POST',
//            });

//            const result = await response.json();

//            if (response.ok && result.success) {
//                alert(result.message);
//                window.location.href = '/Pizzas/Pizzas';
//            } else {
//                alert(result.message || 'Failed to delete the pizza.');
//            }
//        } catch (error) {
//            alert('An error occurred while trying to delete the item.');
//        }
//    });

    
//    confirmNo.addEventListener('click', function () {
//        confirmationPopUp.style.display = 'none';
//    });
//});
