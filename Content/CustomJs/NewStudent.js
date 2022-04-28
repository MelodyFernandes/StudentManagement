$(document).ready(function () {

    $("#newstudform").submit(function (e) {

        e.preventDefault(); // avoid to execute the actual submit of the form.

        var form = $(this);
        var actionUrl = form.attr('action');

        //Validation
        var isValid = true;

        console.log('before submit');
        if (isValid) {
            $.ajax({
                type: "POST",
                url: actionUrl,
                data: form.serialize(), // serializes the form's elements.
                success: function (data) {
                    alert(data); // show response from the php script.
                }
            });
        }
       
        console.log('after submit');
    });


    $("#addC").click(function () {
        $("#addCDiv").attr("style", "display:block")
    });

    $("#addO").click(function () {
        $("#addODiv").attr("style", "display:block")
    });


    $("#Department").change(function () {
        $('#Subject1').empty();
        $('#Subject2').empty();
        $('#Subject3').empty();
        $('#SubjectOp1').empty();
        $('#SubjectOp2').empty();
        var depId = $("#Department").val();
        var op1 = true;
        var op2 = false;
        $.ajax({
            type: "GET",
            url: "/Home/GetSubject?depId=" + depId +"&optional="+op2,
            dataType: "json",
            success: function (data) {
                console.log(data);
                var t = "<option value=''>Select Subject</option>";
                $(t).appendTo('#Subject1');
                $(t).appendTo('#Subject2');
                $(t).appendTo('#Subject3');
                $.each(data, function (i, obj) {
                    console.log(obj.Id + ":" + obj.Name);
                    var div_data = "<option value=" + obj.Id + ">" + obj.Name + "</option>";
                    console.log(div_data);
                    $(div_data).appendTo('#Subject1');
                    $(div_data).appendTo('#Subject2');
                    $(div_data).appendTo('#Subject3');
                });
            }
        });

        $.ajax({
            type: "GET",
            url: "/Home/GetSubject?depId=" + depId +"&optional="+op1,
            dataType: "json",
            success: function (data) {
                console.log(data);
                var t = "<option value=''>Select Subject</option>";
                $(t).appendTo('#SubjectOp1');
                $(t).appendTo('#SubjectOp2');
                $.each(data, function (i, obj) {
                    console.log(obj.Id + ":" + obj.Name);
                    var div_data = "<option value=" + obj.Id + ">" + obj.Name + "</option>";
                    console.log(div_data);
                    $(div_data).appendTo('#SubjectOp1');
                    $(div_data).appendTo('#SubjectOp2');
                });
            }
        });
    });
})

