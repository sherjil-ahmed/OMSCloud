$(document).ready(function () {


    $("#file").change(function () {

        var File = this.files

        if (File && File[0]) {
            ReadImage(File[0]);

        }


    })
})
var ReadImage = function (file) {

    var reader = new FileReader;
    var image = new Image;

    reader.readAsDataURL(file);
    reader.onload = function (_file) {

        image.src = _file.target.result;
        image.onload = function () {

            var height = this.height;
            var width = this.width;
            var type = file.type;
            var size = ~~(file.size / 1024) + "KB";

            $("#targetImg").attr('src', _file.target.result);
            $("#description").text("Size:" + size + ", " + height + "X " + width + ", " + type + "");
            $("#imgPreview").show();

        }

    }

}

var ClearPreview = function () {
    $("#file").val('');
    $("#description").text('');
    $("#imgPreview").hide();

}

$(document).ready(function () {
    $('input[type=file]').change(function () {
        var val = $(this).val().toLowerCase();
        var regex = new RegExp("(.*?).(jpg|jpeg|png|gif|bmp)$");
        if (!(regex.test(val))) {
            $(this).val('');
            alert('Incorrect file selected!!');
            $("#image-holder").hide();
        }
    });
});




