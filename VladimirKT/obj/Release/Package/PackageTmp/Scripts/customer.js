$(document).ready(function () {


	$('#buyNewMovie').click(function (e) {
		e.preventDefault();

		var cardNumber = $('#cardNumber').val();
		var validDiv = $('#validationbar');
		var validLabel = $('#validationbar-label');
		var userCardNumber;
		var userCredit;

		if (cardNumber.length == 7) {
			validDiv.hide();
			console.log(cardNumber);
			$.ajax({
				url: '/Customer/GetCustomerJsonData',
				dataType: 'json',
				async: false,
				success: function (data) {
					userCardNumber = data.CardNumber;
					userCredit = data.Credit;

				}
			});
			console.log(userCardNumber);
			console.log(userCredit);
			if (cardNumber == userCardNumber) {
				validDiv.hide();
				if (userCredit >= 25) {

					$('form#buyMovie').submit();

				} else {
					validDiv.show();
					validLabel.text("Sorry, but you do not have enough credit!");

				}

			} else {
				validDiv.show();
				validLabel.text("Card number is not valid. Please enter correct number!");
			}

		} else {

			validDiv.show();
			validLabel.text("Please enter valid number with 7 digits!");

		}


	})



})