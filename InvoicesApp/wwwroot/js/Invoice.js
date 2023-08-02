
let ddlCategoryId = document.getElementById("ddlCategoryId");
let ddlProduct = document.getElementById("ddlProduct");
let quntity = document.getElementById("quntity");
let price = document.getElementById("price");
let BTotal = document.getElementById("afterDescount");


//Retuer Product Where CategoryId

ShowProduct = () => {
    if ($('#ddlCategoryId').val() == "") {
        $('#ddlProduct').html(`<option value="">Select product name</option>`);
    }
    else {

        $.ajax({
            url: `/Home/GetProduct/${ddlCategoryId.value}`,
            method: 'GET',
            cache: false,
            success: (data) => {

                let Product = '';
                Product += `<option value="">Select product name </option>`;
                let x = 0;
                for (x in data) {

                    Product += `<option value="${data[x].id}">${data[x].name}</option>`;
                    x++;
                }
                $('#ddlProduct').html(Product);
            }
        });
    }


}

ShowPrice = () => {

        $.ajax({
            url: `/Home/GetProductPrice/${ddlProduct.value}`,
            method: 'GET',
            cache: false,
            success: (data) => {


                $('#price').val(data.price);



            }
        });

    


  
    

}

SavaPrducts = () => {
    let obj = {
        CategoryId: ddlCategoryId.value,
        ProductId: ddlProduct.value,
        Quantity: quntity.value,
        Price: price.value,
        Total: price.value * quntity.value,
    }
    let data = JSON.stringify(obj);
    $.ajax({
        url: 'api/Invoice',
        method: 'POST',
        data: data,
        contentType: 'application/json',
        cache: false,
        success: (data) => {


            //alert('Sava Data');
            ResetData();
            ShowTable();
            GetTotal();
            Discount();
           

        }
    });







}


ResetData = () => {
    ddlCategoryId.value = '';
    ddlProduct.value = '';
    quntity.value = 1;
    price.value = 0;
};

ShowTable = () => {

    $.ajax({

        url: 'api/Invoice',
        method: 'GET',
        cache: false,
        success: (data) => {

            let Table = '';

            for (x in data) {

                Table += `
                  <tr>
                    <td>#</td>
                    <td>${data[x].category.categoryName}</td>
                    <td>${data[x].product.name}</td>
                    <td>${data[x].price}</td>
                    <td>${data[x].quantity}</td>
                    <td>${data[x].total}</td>
                    <td><a class="btn btn-danger" onclick="DeleteProduct(${data[x].invoiceId})" style="color:#ffff"><i class="fa fa-trash"></i></a></td>
                </tr>`;
            }
            $('#tablebody').html(Table);
        }
    });

};
GetTotal = () => {

    $.ajax({
        url: `api/Invoice/GetTotal`,
        method: 'GET',
        cache: false,
        success: (data) => {
        //    $('#allTotal').val(data);
            $('#afterDescount').val(data);

        }
    });

};
Discount = () => {

    $.ajax({
        url: `api/Invoice/Discount`,
        method: 'GET',
        cache: false,
      
        success: (data) => {
            $('#discount').val(data);
            $('#allTotal').val($('#afterDescount').val() - data);
        
        }
            
    });

};


