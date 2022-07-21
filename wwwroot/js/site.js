$(document).ready(function () {

    $(".ContactInfoTable").dialog({
        autoOpen: false,
        show: {
            effect: "blind",
            duration: 1000
        },
        hide: {
            effect: "explode",
            duration: 1000
        },
        resizable: true,
        width: '80%',
        icon: "ui-icon-heart",
        closeClass: 'icon-remove',
    });
    $(".AddressDetailsTable").dialog({
        autoOpen: false,
        show: {
            effect: "blind",
            duration: 1000
        },
        hide: {
            effect: "explode",
            duration: 1000
        },
        icon: "ui-icon-heart",
        resizable: true,
        width: '80%',
    });

    $("#DisplayContactDetails").on("click", function () {
        $(".ContactInfoTable").dialog("open");
    });
    $("#DisplayAddressDetail").on("click", function () {
        $(".AddressDetailsTable").dialog("open");
    });
});