function Product() {
    var self = this;

    //not show error DataTable
    $.fn.dataTable.ext.errMode = 'none';

    //.................Products
    $('#ProductsDataTable').DataTable({
        ordering: true,
        pageLength: 10,
        responsive: true,
        searching: true,
        filter: true,
        paging: true,
        ajax: {
            url: "/Home/get-products/",
            type: "POST",
            datatype: "application/json"
        },
        columnDefs: [
            { width: "10%", targets: 0 },
            { width: "20%", targets: 1 },
            { width: "20%", targets: 2 },
            { width: "10%", targets: 3 },
            { width: "50%", targets: 4 }
        ],
        columns: [
            { data: "ProductId" },
            { data: "ProductName" },
            { data: "UnitTitle" },
            { data: "Count" },
            {
                "render": function (data, type, row) {
                    if (data === "no data") {
                        return [];
                    }
                    else {
                        res = "<a href='javascript:void(0)' onclick=product.UpdateProduct('" + row.ProductId + "','" + row.ProductName + "','" + row.UnitId + "','" + row.Count + "') class='btn btn-sm btn-warning'><i style='font-size:14px' class='fa fa-edit'></i></a> " +
                            "<a href='javascript:void(0)' onClick='product.DeleteProduct(" + row.ProductId + ")' class='btn btn-sm btn-danger'><i style='font-size:14px' class='fa fa-trash'></i></a";
                        return res;
                    }
                }
            }
        ]
    });

    self.refreshProductsDataTable = function () {
        $('#ProductsDataTable').DataTable().ajax.reload();
    };

    $('#btnAddProduct').click(function () {
        $('#txtProductName').val("");
        $('#txtUnitId').val("");
        $('#txtCount').val("");
        $('#ModifyProductModalTitle').html("افزودن محصول");
        $('#ModifyProductModal').data('productId', 0);
        $('#ModifyProductModal').modal();
    });

    $('#btnModifyProduct').click(function () {
        var msg = CheckValidData();
        if (msg === "") {
            var data = {
                productId: $('#ModifyProductModal').data('productId'),
                productName: $('#txtProductName').val(),
                unitId: $('#txtUnitId').val(),
                count: $('#txtCount').val()
            };
            $.ajax({
                type: 'POST',
                url: '/Home/Modify-product',
                data: data,
                dataType: "text",
                traditional: true,
                success: function (res) {
                    var result = JSON.parse(res);
                    if (result.isValid === true) {
                        self.refreshProductsDataTable();
                        $('#ModifyProductModal').modal('hide');
                    }
                    if (result.isValid === false) {
                        self.setModalResult(result.isValid, result.msg);
                    }
                },
                error: function (err) {
                    self.setModalResult(false, "خطایی رخ داده است");
                }
            });
        } else {
            self.setModalResult(false, msg);
        }
    });

    self.DeleteProduct = function (productId) {
        let parametres = [{ key: "productId", val: [productId] }];
        let message = "آيا از حذف اين محصول مطمن هستيد؟";
        let onYesClick = 'product.btnDeleteProduct()';
        self.MessageBoxWithYesNoButton(parametres, message, onYesClick);
    };

    self.btnDeleteProduct = function () {

        var id = $('#MessageBoxWithYesNO').data('productId');

        $.ajax({
            type: 'DELETE',
            url: '/Home/delete-product/' + id,
            dataType: "Text",
            traditional: true,
            success: function (res) {
                var data = JSON.parse(res);

                if (data.isValid === true) {
                    self.refreshProductsDataTable();
                    self.HideMessageBoxWithButton();
                }
                if (data.isValid === false) {
                    self.HideMessageBoxWithButton();
                    self.setModalResult(data.isValid, data.msg);
                }
            },
            error: function (err) {
            }
        });
    };

    self.UpdateProduct = function (productId, productName, unitId, count) {
        $('#txtProductName').val(productName);
        $('#txtUnitId').val(unitId);
        $('#txtCount').val(count);

        $('#ModifyProductModal').data('productId', productId);
        $('#ModifyProductModalTitle').html("ویرایش محصول");
        $('#ModifyProductModal').modal();
    };

    function CheckValidData() {
        let productName = $('#txtProductName').val();
        let unitId = $('#txtUnitId').val();
        let count = $('#txtCount').val();

        if (productName === "") {
            return "عنوان محصول را وارد کنید";
        } else if (unitId === "") {
            return "واحد شمارش را انتخاب کنید";
        } else if (count === "") {
            return "تعداد  را وارد کنید";
        } else {
            return "";
        }
    }


    self.MessageBoxWithYesNoButton = function (parameters, modalMessage, actionButtonYes) {

        let messageBox = $('#MessageBoxWithYesNO');
        let messageBoxText = $('#message-box-text');

        for (var i = 0; i < parameters.length; i++) {
            var key = parameters[0].key;
            var value = parameters[0].val;
            messageBox.data(key, value);
        }
        messageBoxText.html(modalMessage);
        $('#btnYesAction').attr("onclick", actionButtonYes);
        messageBox.modal();
    }

    self.HideMessageBoxWithButton = function () {
        let messageBox = $('#MessageBoxWithYesNO');
        messageBox.modal('hide');
    };

    self.setModalResult = function (status, message) {
        var modalMessage = $("#MessageBox-message");
        var modalHeader = $("#message-box-header");

        if (status === true) {
            modalMessage.css("color", "black");
            modalHeader.removeClass("alert-danger").addClass("alert-success");
        } else {
            modalMessage.css("color", "red");
            modalHeader.removeClass("alert-success").addClass("alert-danger");
        }
        modalMessage.html(message);
        $('#MessageBox').modal();
    };

}

var product = new Product();
