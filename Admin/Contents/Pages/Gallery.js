

var saveGallery = function () {
    var message = "";

    $formData = new FormData();

    var title = $("#txttitle").val();
    var image = document.getElementById('fuphoto1');
    



    if (image.fileslength > 0) {
        for (var i = 0; i < image.files.length; i++) {
            $formData.append('file-' + i, image.files[i]);
        }
    }

    $formData.append('Title', title);
    $formData.append('Image', image);
    
    $.ajax({
        url: "/YogaGallery/SaveGallery",
        method: "post",
        data: $formData,
        processData: false,
        contentType: false,
        dataType: "json",
        success: function (response) {
            alert("submitted");
        }

    })
};

