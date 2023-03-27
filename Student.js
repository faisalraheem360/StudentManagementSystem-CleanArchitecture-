
$('#tbllist').ready(function () {
    table = $('#tbllist').DataTable({
        "searching": false,
        "ajax": {
            "type": "GET",
            "url": "https://localhost:7059/api/Student",
            "dataSrc": function (json) {
                //Make your callback here.
               // alert("Done!");
               return json.data;
            }
        },
        "columns": [
            { "data": "stuId" },
            { "data": "name" },
            { "data": "fatherName" },
            { "data": "age" },
            { "data": "standard" },
            {
                "data":"stuId",
                mRender: function (data, type, row) {
                    return '<button type = "button" data-target="#AddStudent"class="btn btn-danger Delete_Btn" data-id="' + data + '">DELETE</button > <button type = "button" class="btn btn-primary Edit_Btn" data-id="' + data + '"onclick="getForm(' + data + ')">Edit</button >';
                }
            },          
        ]
    });
});
//Delete Method with ajax
$(document).on('click', '.Delete_Btn', function () {
    let stuId = $(this).data('id');
    console.log(stuId);
    if (confirm('Are you Sure to delete?')) {
        DeleteStudent(stuId);
    } else {
        alert("not deleted");
        table.ajax.reload();
    }
});

function DeleteStudent(data) {
    $.ajax({
        url: 'https://localhost:7059/api/Student/DeleteStudent/' + data,
        dataType: "json",
        success: function (data) {
            table.ajax.reload();
        },
        error: function () {
        }
    });
}

$(document).on('click', '.Edit_Btn', function () {
    $('#AddStudent').modal('show'); 
});

/*Get Form*/
function getForm(id = 0) {
            $.ajax({
                url: 'https://localhost:7059/api/Student/GetStudentByID/' + id,
                data: $("form").serialize(),
                success: function (data) {
                    console.log(data)
                    $('#name').val(data.name)
                    $('#age').val(data.age)
                    $('#stuId').val(data.stuId)
                    $('#fname').val(data.fatherName)
                    $('#standard').val(data.standard)
                }
            });
        
}

$('#savebtn').on('click', function () {
    //debugger
    SaveStudent();
    // refreshPage();
    console.log($("form").serialize())
    var formData = {
        StuId: $("#stuId").val(),
        Name: $("#name").val(),
        FatherName: $("#fname").val(),
        Age: $("#age").val(),
        Standard: $("#standard").val(),

    };
    console.log(JSON.stringify(formData));
    $.ajax({
        url: 'https://localhost:7059/api/Student',
        headers: {
            'Content-Type': 'application/json',
            /*'charset': 'utf-8'*/
        },
        type: "Post",
        data: JSON.stringify(formData),
        success: function (data) {
            if (StuId == null || StuId == 0) {
                $('#AddStudent').modal('hide');
            }
            table.ajax.reload();
            

        }
    });
})

$('#addbtn').on('click', function () {
    $('#AddStudent').modal('hide');
})
function SaveStudent() {

    $('#AddStudent').modal('hide'); 
    /*setInterval('refreshPage()');*/
 
}
 
function refreshPage() {
    location.reload(true);
}