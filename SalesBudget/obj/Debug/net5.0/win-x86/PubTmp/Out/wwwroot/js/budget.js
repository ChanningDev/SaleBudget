var datatable;

$(document).ready(function () {
    loadDataTable();
});



$(document).ready(function () {
    $('#tblIndex').DataTable();
});



function loadDataTable() {

    dataTable = $('#tblIndex').DataTable({
        "ajax": {
            "url": "/Admin/budget/getAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "customer.customerName" },
            { "data": "itemMaster.itemDescription" },
            { "data": "currency" },
            { "data": "freeOfCharge" },
            { "data": "unitOfMeasure" },
            { "data": "unitPrice" },
            { "data": "quantity" },
            { "data": "totalAmount" },

            {
                "data": "budgetId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/budget/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer; width: 50px;">
                                    <i class="far fa-edit"></i>
                                </a>
                                </br>
                                <a onclick=Delete("/Admin/budget/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width: 50px;">
                                    <i class="far fa-trash-alt"></i>
                                </a>
                            </div>
                            `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No records found"
        },
        "width": "50%"
    });

}

function Delete(url) {
    swal({
        title: "Are you sure you wnat to delete?",
        text: "You will not be able to recover the content.",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it.",
        closeOnConfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    ShowMessage(data.message);
                    dataTable.ajax.reload();
                } else {
                    toastr.error(data.message);
                }
            }
        });
    });
}

function ShowMessage(msg) {
    toastr.success(msg);
}
