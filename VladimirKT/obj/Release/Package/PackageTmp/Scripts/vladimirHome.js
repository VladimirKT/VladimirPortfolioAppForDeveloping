$(document).ready(function () {
	
	var mainImage1 = $("#mainImage1");
	var mainImage2 = $("#mainImage2");
	var mainImage3 = $("#mainImage3");
	var mainImage4 = $("#mainImage4");
	var mask4 = $("#mask4");
	var mask5 = $("#mask5");
	var mask6 = $("#mask6");
	var centraL = $("#central");
	
	function PhotoMove() {

		centraL.animate({
			opacity: '1'
		}, 10000)

		mask4.animate({
			opacity: '1',
			fontSize: '300%'
		}, 60000, function () {
			mask4.animate({
				left: '-500px'
			}, 60000)
		});

		mask6.animate({
			opacity: '1',
			fontSize: '300%'
		}, 40000, function () {
			mask6.animate({
				left: '-500px'
			}, 80000)
		});

		mainImage1.animate({
			left: '-1332px',

		}, 60000, function () {
			mainImage1.css({ left: "1332px" });
			mainImage1.animate({
				left: '0',
			}, 60000)

		});

		mainImage2.animate({
			left: '-666px',

		}, 60000, function () {
			mainImage2.css({ left: "1998px" });
			mainImage2.animate({
				left: '666px',
			}, 60000)

		});

		mainImage3.animate({
			left: '0px',

		}, 60000, function () {
			mainImage3.css({ left: "0" });
			mainImage3.animate({
				left: '-1332px',
			}, 60000)
		});

		mainImage4.animate({
			left: '666px',

		}, 60000, function () {
			mainImage4.css({ left: "666px" });
			mainImage4.animate({
				left: '-666px',
			}, 60000, function () {
				mainImage1.css({ top: 0, left: 0 });
				mask4.css({ top: 0, left: 0, opacity: '0' });
				mask6.css({ top: '80%', left: '50%', opacity: '0' });
				mainImage2.css({ top: 0, left: "666px" });
				mainImage3.css({ top: 0, left: "1332px" });
				mainImage4.css({ top: 0, left: "1998px" });
				PhotoMove();
			} )
		});

	}
	  PhotoMove();

})