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

    $("#DisplayContactDetails").on("click", function (e) {
        e.preventDefault();
        $(".AddressDetailsTable").dialog("close");
        $(".ContactInfoTable").dialog("open");
    });
    $("#DisplayAddressDetail").on("click", function (e) {
        e.preventDefault();
        $(".AddressDetailsTable").dialog("open");
        $(".ContactInfoTable").dialog("close");
    });
});