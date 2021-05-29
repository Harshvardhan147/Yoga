////$(document).ready(function () {

////    //alert("Category added Sucessfully");
////    DisplayGalleryList();

////});

var saveGallery = function () {
    var message = "";

    $formData = new FormData();

    var title = $("#txttitle").val();
    var location = $("txtlocation").val();
    var organizedby = $("txtorganizedby").val();
    var photo1 = document.getElementById('fuphoto1');
    var photo2 = document.getElementById('fuphoto2');
    var date = $("txtdate").val();



    if (photo1.fileslength > 0) {
        for (var i = 0; i < image.files.length; i++) {
            $formData.append('file-' + i, photo1.files[i]);
        }
    }

    if (photo2.files.length > 0) {
        for (var i = 0; i < photo2.files.length; i++) {
            $formData.append('file-' + i, photo2.files[i]);
        }
    }

    $formData.append('Title', title);
    $formData.append('Location', location);
    $formData.append('Organizedby', organizedby);
    $formData.append('Photo1', photo1);
    $formData.append('Photo2', photo2);
    $formData.append('Date', date);

    $.ajax({
        url: "/AddGallery/SaveGallery",
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

//var DisplayGalleryList = function () {
//    $.ajax({
//        url: "/Addgallery/DisplayGalleryList",
//        method: 'post',
//        //data: JSON.stringify(model),
//        contentType: "application/json;charset=utf-8",
//        datatype: "json",
//        async: false,
//        success: function (response) {
//            console.log(response)
//            var html = "";
//            $("#tblGallery tbody").empty();
//            $.each(response.model, function (index, elementValue) {

//                html += "<tr><td>" + elementValue.Id + "</td><td>" + elementValue.Title + "</td><td>" + elementValue.Photo1 + "</td><td><img src='../Content/imgs/"+ elementValue.Photo2 + "</td><td><img src='../Content/imgs/" + "'/> + elementValue.Date </td></tr>";

//            });
//            $("#tblGallery tbody").append(html);
//        }
//    });
//}