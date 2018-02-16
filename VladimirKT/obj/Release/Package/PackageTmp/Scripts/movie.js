$(document).ready(function () {

	var pathForDelete = [];
	var imageMovieArr = ["aliens.jpg", "allen.jpg", "america.jpg", "avatar.jpg", "bartonFink.jpg", "braveheart.jpg", "brpith.jpg", "devid.jpg", "charli.jpg", "eyes.jpg", "english.jpg", "fargo.jpg", "fifthElement.jpg", "forestGump.jpg", "great.jpg", "heat.jpg", "hofman.jpg", "indiana.jpg", "jango.jpg", "jery.jpg", "james.jpg", "woody.jpg", "johnie.jpg", "jfk.jpg", "lebovski.jpg", "schlist.jpg", "lords.jpg", "poker.jpg", "pulpFiction.jpeg", "lordss.jpg", "rian.jpg", "natural.jpg", "lebowski.jpg", "taxidriver.jpg", "nixon.jpg", "old.jpg", "savages.jpg", "theGodfather3.jpg", "theGreenMile.jpg", "schindlers.jpg", "senta.jpg", "tenk.jpg", "shosenk.jpg", "thedoors.jpg"]
	var imageCartoonArr = ["aladin.jpg", "animals.jpg", "bart.jpg", "boy.jpg", "cinderrel.jpg", "dogs.jpg", "elsa.jpg", "ffrozen.jpg", "frozen.jpg", "hercules.jpg", "homer.jpg", "lion.jpg", "madagascar.jpg", "mermaid.jpg", "moana.jpg", "obelix.jpg", "shrek.jpg", "shrekk.jpg", "sing.jpg", "spark.jpg", "tiana.jpg", "toys.jpg", "toyss.jpg", "wolf.jpg"]
	var count = 0;
	var counter = 0;
	$('#sliderImage1').attr('src', "/Content/Images/forSlider/" + imageMovieArr[count])
	$('#sliderImage2').attr('src', "/Content/Images/forSecondSlider/" + imageCartoonArr[counter])
	setInterval(function () {
		$('#sliderImage1').attr('src', "/Content/Images/forSlider/" + imageMovieArr[count]);
		$('#sliderImage2').attr('src', "/Content/Images/forSecondSlider/" + imageCartoonArr[counter]);
		count++;
		counter++;
		if (count == imageMovieArr.length - 1) {
			count = 0;
		}
		if (counter == imageCartoonArr.length - 1) {

			counter = 0;
		}

	}, 4000);


	setInterval(function () {

		($('#textDiv').hide(2000));

		$('#textDiv').show(2000);

	}, 11000);

 
	var pathForDelete = [];
	$('#uploadImage').on('change', function (e) {
		  e.preventDefault();

		  var files = $('#uploadImage')[0].files;

		  if (files.length > 0
			  && (files[0].type == "image/jpg"
				  || files[0].type == "image/png"
				  || files[0].type == "image/jpeg")) {

			  var url = URL.createObjectURL(this.files[0]);
			  var img = new Image;
			  img.onload = function () {
				  var width = img.width;
				  var heigth = img.height;
				  if (width == 550 && heigth == 350) {

					  var formData = new FormData();

					  for (var i = 0; i < files.length; i++) {

						  formData.append(files[i].name, files[i]);
					  }

					  var progressbarDiv = $('#progressbar');
					  var progressbarLabel = $('#progressbar-label');
					  var validDiv = $('#validDiv');
					  $("#submitNewMovie").removeAttr('disabled');

					  $.ajax({
						  url: "/Movie/UploadImage", 
						  method: "POST",
						  cache: 'false',
						  async: false,
						  data: formData,
						  contentType: false,
						  processData: false,
						  success: function () {
							  $("#newImageDiv").css({ display: "none" });
							  validDiv.fadeOut()
							  $('#uploadImage').hide();
							  progressbarLabel.text("Image uploaded");
							  progressbarDiv.show();					 
							
							  var newSrc = '/Content/Images/movies/' + files[0].name;
							  pathForDelete.push(newSrc);
							  console.log(newSrc);							  

							  $('#movieImage').attr('src', newSrc);
							  $("#movieImage").css({ display: "block" });
						  },
						  error: function () {
							  progressbarLabel.text("Error detected");
							  progressbarDiv.show();
							  progressbarDiv.fadeOut(10000);
						  }
					  });
				  } else {
					  validationDimension();
				  }
			  }; img.src = url;
		  } else if (files.length > 0) {
			  validationExtension();
		  }
	});

	$('#cancelNewMovie').click(function (e) {
		e.preventDefault();

		if (pathForDelete.length > 0) {
			var forDelete = pathForDelete.shift();
			$.ajax({
				async: false,
				url: "/Movie/DeleteImage",
				type: 'POST',
				data: { imagePath: forDelete }
			});
		}
		window.location = '/Movie/ListOfMovies';
	});

	  function validationExtension() {

		  $("#submitNewMovie").attr("disabled", "disabled");
		  var validDiv = $('#validDiv');
		  var validLabel = $('#validLabel');
		  validLabel.text("Please upload image with valid extension: jpg or png");
		  validDiv.show();
       };

	  function validationDimension() {
		  $("#submitNewMovie").attr("disabled", "disabled")
		  var validDiv = $('#validDiv');
		  var validLabel = $('#validLabel');
		  validLabel.text("Please upload image dimension 550 x 350 px");
		  validDiv.show();
	  };


	  var pathForDeleteInEdit = [];
	  $('#editUploadImage').on('change', function (e) {
		  e.preventDefault();

		  var files = $('#editUploadImage')[0].files;

		  if (files.length > 0
			  && (files[0].type == "image/jpg"
				  || files[0].type == "image/png"
				  || files[0].type == "image/jpeg")) {

			  var url = URL.createObjectURL(this.files[0]);
			  var img = new Image;
			  img.onload = function () {
				  var width = img.width;
				  var heigth = img.height;
				  if (width == 550 && heigth == 350) {

					  var formData = new FormData();

					  for (var i = 0; i < files.length; i++) {

						  formData.append(files[i].name, files[i]);
					  }

					  var progressbarDiv = $('#progressbar');
					  var progressbarLabel = $('#progressbar-label');
					  var validDiv = $('#validDiv');
					  $("#submitNewMovie").removeAttr('disabled');

					  $.ajax({
						  url: "/Movie/UploadImage",
						  method: "POST",
						  cache: 'false',
						  async: false,
						  data: formData,
						  contentType: false,
						  processData: false,
						  success: function () {
							  $("#newImageDiv").css({ display: "none" });
							  validDiv.fadeOut()
							  $('#editUploadImage').hide();
							  progressbarLabel.text("Image uploaded");
							  progressbarDiv.show();

							  var newSrc = '/Content/Images/movies/' + files[0].name;
							  pathForDeleteInEdit.push(newSrc);
							  console.log(newSrc);

							  $('#editNewMovieImage').attr('src', newSrc);
							  $("#editMovieImage").css({ display: "none" });
							  $("#editNewMovieImage").css({ display: "block" });
						  },
						  error: function () {
							  progressbarLabel.text("Error detected");
							  progressbarDiv.show();
							  progressbarDiv.fadeOut(10000);
						  }
					  });
				  } else {
					  validationDimension();
				  }
			  }; img.src = url;
		  } else if (files.length > 0) {
			  validationExtension();
		  }
	  });

	  $('#cancelEditMovie').click(function (e) {
		  e.preventDefault();

		  if (pathForDeleteInEdit.length > 0) {
			  var forDelete = pathForDeleteInEdit.shift();
			  $.ajax({
				  async: false,
				  url: "/Movie/DeleteImage",
				  type: 'POST',
				  data: { imagePath: forDelete }
			  });
		  }
		  window.location = '/Movie/ManageListOfMovies';
	  });


	  $("#moviesTable").DataTable({
		  ajax: {
			  url: "/Movie/GetJsonDataForMovies",
			  dataSrc: ""
		  },
		  columns: [

			  {
				  data: "ImagePath",
				  render: function (data, type) {
					  return '<img class="tableImage"  src="' + data +'"  style="width: 100px; height: auto; max-width: 100px; max-height: auto"/>';
				  }
			  },

			  {
				  data: "Name"
			  },
			  {
				  data: "Genre"
			  },
			  {
				  data: "Price"
			  },
			  {
				  data: "Id",
				  render: function (data, type) {
					  return "<a class='btn btn-success' href='/Movie/MovieDetails/" + data + "'>Details</a>";
				  }
			  }
		  ]

	});



	  $("#manageMoviesTable").DataTable({
		  ajax: {
			  url: "/Movie/GetJsonDataForMovies",
			  dataSrc: ""
		  },
		  columns: [

			  {
				  data: "ImagePath",
				  render: function (data, type) {
					  return '<img class="tableImage"  src="' + data + '"  style="width: 100px; height: auto; max-width: 100px; max-height: auto"/>';
				  }
			  },
			  {
				  data: "Name"
			  },
			  {
				  data: "Id",
				  render: function (data, type) {
					  return "<a class='btn btn-success' href='/Movie/MovieDetails/" + data + "'>Details</a>";
				  }
			  },

			  {
				  data: "Id",
				  render: function (data, type) {
					  if (data < 28) {
						  return "<a disabled class='btn btn-warning' href='/movie/EditMovie/" + data + "'>Edit</a>";
					  } else {
						  return "<a class='btn btn-warning' href='/movie/EditMovie/" + data + "'>Edit</a>";
					  }
				  }
			  },
			  {
				  data: "Id",
				  render: function (data, type) {
					  if (data < 28) {
						  return "<button disabled data-customer-id=" + data + " class='btn btn-danger js-delete'>Delete</button>";
					  } else {
						  return "<button data-customer-id=" + data + " class='btn btn-danger js-delete'>Delete</button>";
					  }
				  }
			  }

		  ]

	});

		  //$("#customers .js-delete").on("click", function () {
	  //so we put .js-delete like filter to optimize code and memory
	  $("#manageMoviesTable").on("click", ".js-delete", function () {
		  var button = $(this);
		  bootbox.confirm("Are you sure you want to delete this movie?", function (result) {
			  if (result) {
				  $.ajax({
					  url: "/Movie/DeleteMovie/" + button.attr("data-customer-id"),//also we can replace $(this) with button
					  method: "POST",
					  success: function () {
						  button.parents("tr").remove();//like here
					  },
					  error: function () {
						  alert("Neeeeeeeeeeeeeeeeeeeeeeee")
					  }
				  });
			  }
		  });

	  });



});