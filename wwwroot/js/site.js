$(document).ready(function () {
    $(".ContactInfoTable").dialog({
        autoOpen: false,
        width: '80%',
        icon: "ui-icon-heart",
        closeClass: 'icon-remove',
    });
    $(".AddressDetailsTable").dialog({
        autoOpen: false,
        resizable: true,
        width: '80%',
    });
    $(".datepicker").datepicker("option", "dateFormat", "dd-M-y");
    $(".DisplayContactDetails").on("click", function (e) {
        e.preventDefault();
        // $(".modal").dialog("close");
        $("div").find(`[data-Contact-details-table='${$(this).attr('data-id')}']`).dialog("open");
    });
    $(".DisplayAddressDetail").on("click", function (e) {
        e.preventDefault();
        // $(".modal").dialog("close");
        $("div").find(`[data-address-details-table='${$(this).attr('data-id')}']`).dialog("open");
    });
    $("#Department").change(function () {
        $.getJSON("/Staff/GetJobList", { DepartmentId: parseInt($("#Department").val()) }, function (data) {
            let row = "";
            $("#JobTitle").empty();
            $.each(data, function (index, item) {
                row += "<option value=" + item.value + ">" + item.text + "</option>";
            });
            $("#JobTitle").html(row);
        })
    })
});