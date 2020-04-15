// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var $ = function (id) { return document.getElementById(id); };
window.onload = function () {
	var listNode = $("image_list");
	var captionNode = $("caption");
	var imageNode = $("image");
	var links = listNode.getElementsByTagName("a");

	//process image links
	var i, linkNode, image;
	var imageCache = [];
	for (i = 0; i < links.length; i++) {
		linkNode = links[i];
		//preload images an copy title properties.
		image = new Image();
		image.src = linkNode.getAttribute("href");
		image.title = linkNode.getAttribute("title");
		imageCache[imageCache.length] = image;
	}
	//start slide show
	var imageCounter = 0;
	var timer = this.setInterval(
		function () {
			imageCounter = (imageCounter + 1) % imageCache.length;
			image = imageCache[imageCounter];
			imageNode.src = image.src;
			captionNode.firstChild.nodeValue = image.title;
		},
		2000);
};

$("H1").hover(
	function () {
		alert("The mouse pointer is over the H1 element");
	};