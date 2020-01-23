function UploadPictures(picsData) {
	return $.ajax({
		url: $("#uploadPicturesLink").val(),
		type: "post",
		data: picsData,
		dateType: "json",
		processData: false,
		contentType: false
	});
}

function removeThis(elem) {
	$(elem).remove();
}

function removeImage(elem) {
	$(elem).parents(".card").remove();
}