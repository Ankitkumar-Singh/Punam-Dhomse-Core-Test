$(document).ready(function () {

    $('#btnDelete').click(function () {
        toastr.success('Deleted successfully.');
    })

    $('#myForm').submit(function () {
        if ($(this).valid())
            toastr.success("Product added successfully");
        else
            toastr.warning("Please enter the valid values.");
    })

    $('#categoryForm').submit(function () {
        if ($(this).valid())
            toastr.success("Category added successfully");
        else
            toastr.warning("Please enter the valid values.");
    })
});

