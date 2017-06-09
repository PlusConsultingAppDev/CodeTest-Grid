/// <reference path="../jquery-2.2.4.min.js" />
/// <reference path="../jquery.validate.min.js" />
/// <reference path="http://ajax.aspnetcdn.com/ajax/jquery.templates/beta1/jquery.tmpl.js" />
/// <reference path="../jquery-2.2.4.min.js" />

$(function () {
	var products = undefined;
	function getAllProducts() {
		$.ajax({
			url: '/Products/GetAllProducts',
			type: 'GET',
			dataType: 'JSON'
		}).success(function (result) {
			products = result;

			for (let i = 0; i < 5; i++) {
				$("#gridRow").tmpl(products[i]).appendTo("#product-table-body");
			}
			$("#back-button").addClass('not-active');
		}).fail(function(xhr, status, message) {
			console.log(xhr);
		});
	}

	function getNextProducts(pageNumber) {
		var endNumber = pageNumber * 5;
		var startNumber = endNumber - 5;
		$("#product-table-body").empty();
		for (let i = startNumber; i < endNumber; i++) {
			$("#gridRow").tmpl(products[i]).appendTo("#product-table-body");
		}
		$("#forward-button").attr('data-page', ++pageNumber);
		$("#back-button").attr('data-page', pageNumber - 2);
		if (pageNumber - 2 > 0)
			$("#back-button").removeClass('not-active');
		else
			$("#back-button").addClass('not-active');
	}

	getAllProducts();

	// Navigation Links Buttons
	$("#forward-button").click(function(e) {
		e.preventDefault();
		var pageNumber = $(this).attr('data-page');
		getNextProducts(pageNumber);
	});
	$("#back-button").click(function(e) {
		e.preventDefault();
		var pageNumber = $(this).attr('data-page');
		getNextProducts(pageNumber);
	});

	// Add Button
	$("#add-product-button").click(function(e) {
		//e.preventDefault();
		if ($("#productName").val().length <= 0) {
			alert("You must enter a name");
			return;
		}
		var cost = $("#productCost").val();
		var listPrice = $("#productListPrice").val();
		var reorder = $("#productReorder").val();
		var stockLevel = $("#productStockLevel").val();
		if (cost <= 0) {
			alert("You must enter a Cost greater than 0");
			return;
		}
		if (listPrice <= 0) {
			alert("You must enter a List Price greater than 0");
			return;
		}
		if (reorder <= 0) {
			alert("You must enter a Reorder Value greater than 0");
			return;
		}
		if (stockLevel <= 0) {
			alert("You must enter a Stock Level greater than 0");
			return;
		}


	});
});
