$(function () {
    $("#loaderbody").addClass('hide');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});

showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                } else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

jQueryAjaxDelete = form => {
    if (confirm('Are you sure to delete this record ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html);
                },
                error: function (err) {
                    console.log(err)
                }
            })
        } catch (ex) {
            console.log(ex)
        }
    }

    //prevent default form submit event
    return false;
}


$('.Number').keypress(function (event) {
    var keycode = event.which;
    if (!(event.shiftKey == false && (keycode == 46 || keycode == 8 || keycode == 37 || keycode == 39 || (keycode >= 48 && keycode <= 57)))) {
        event.preventDefault();
    }
});

function formatCurrencyN(n) {
    sep = ".";
    return n.toLocaleString().split(sep)[0];
        // + sep
        // + n.toFixed(decimals).split(sep)[1];
}
function formatCurrency(n, sep, decimals) {
    sep = sep || "."; // Default to period as decimal separator
    decimals = decimals || 2; // Default to 2 decimals

    return n.toLocaleString().split(sep)[0]
        + sep
        + n.toFixed(decimals).split(sep)[1];
}

ajaxGet = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}

ajaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                } else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

ajaxDelete = form => {
    if (confirm('Are you sure to delete this record ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html);
                },
                error: function (err) {
                    console.log(err)
                }
            })
        } catch (ex) {
            console.log(ex)
        }
    }

    //prevent default form submit event
    return false;
}


var detailDairyModel = new bootstrap.Modal(document.getElementById('detailDairyModel'), {
    backdrop: 'static',
    keyboard: false
});

onClickSearch = (e) => {
    debugger;
    if ($('#txtsearchdairynumber').val() != '') {
        
        bindDairyByNumber($('#txtsearchdairynumber').val());        
    } else {
        swal({title: "Please enter dairy number!", icon: "warning",});
        return;
    }
}

bindDairyByNumber = (numb) => {
    $.ajax({
        type: 'GET',
        url: "/dairy/getbynumber/" + numb,
        success: function (res) {
            $('#divDairyDetail').html('');
            if (res.success) {
                _dairy = res.data;
                var _innerBody = "";
                if (_dairy != null) {
                    _innerBody += '<h4>#' + _dairy.dairyNumber + '</h4>';
                    _innerBody += '<table class="table table-borderless">';
                    _innerBody += '    <tr>';
                    _innerBody += '        <td style="width: 110px">Name : </td>';
                    _innerBody += '        <td colspan="3">' + _dairy.customerName + ' S/o ' + _dairy.customerFatherName + ' [' + _dairy.customerMobile + ']</td>';
                    _innerBody += '    </tr>';
                    _innerBody += '    <tr>';
                    _innerBody += '        <td>Start : </td>';
                    _innerBody += '        <td>' + moment(_dairy.startDate).format('DD-MM-YYYY') + '</td>';
                    _innerBody += '        <td>End : </td>';
                    _innerBody += '        <td>' + moment(_dairy.endDate).format('DD-MM-YYYY') + '</td>';
                    _innerBody += '    </tr>';
                    _innerBody += '    <tr>';
                    _innerBody += '        <td>Loan : </td>';
                    _innerBody += '        <td>' + _dairy.loanAmount + '</td>';
                    _innerBody += '        <td>Total : </td>';
                    _innerBody += '        <td>' + _dairy.totalAmount + '</td>';
                    _innerBody += '    </tr>';
                    _innerBody += '    <tr>';
                    _innerBody += '        <td>Balance : </td>';
                    _innerBody += '        <td>' + _dairy.totalBalanceAmount + '</td>';
                    _innerBody += '        <td>Status : </td>';
                    _innerBody += '        <td>' + _dairy.isCompleted + '</td>';
                    _innerBody += '    </tr>';
                    _innerBody += '</table>';

                    if (_dairy.installments?.length > 0) {
                        _innerBody += '<h5>Installments</h5>';
                        _innerBody += '<table class="table table-bordered border-secondary bg-white">';
                        _innerBody += '    <thead>';
                        _innerBody += '    <tr>';
                        _innerBody += '        <th class="text-center">#</th>';
                        _innerBody += '        <th class="text-center">Date</th>';
                        // _innerBody += '        <th class="text-center">Amount</th>';
                        _innerBody += '        <th class="text-center" style="width: 170px">Balance</th>';
                        _innerBody += '        <th class="text-center">Status</th>';
                        _innerBody += '    </tr>';
                        _innerBody += '    </thead>';
                        _innerBody += '    <body>';

                        var todayBalance = 0;
                        for (let j = 0; j < _dairy.installments.length; j++) {
                            var _className = "";

                            if (moment().format('DD-MM-YYYY') == moment(_dairy.installments[j].installmentDate).format('DD-MM-YYYY')) {
                                _className = 'bg-info';
                            } else if (moment() > moment(_dairy.installments[j].installmentDate)) {
                                _className = 'bg-past-dt';
                            }
                            todayBalance += _dairy.installments[j].balanceAmount;


                            _innerBody += '    <tr class="' + _className + '">';
                            _innerBody += '        <td class="text-center">' + _dairy.installments[j].installmentNumber + '</td>';
                            _innerBody += '        <td class="text-center">' + moment(_dairy.installments[j].installmentDate).format('DD-MM-YYYY') + '</td>';
                            // _innerBody += '        <td class="text-end">'+_dairy.installments[j].installmentAmount+'</td>';


                            if (_dairy.installments[j].balanceAmount == 0 || moment().format('DD-MM-YYYY') != moment(_dairy.installments[j].installmentDate).format('DD-MM-YYYY')) {
                                _innerBody += '        <td class="text-end px-1">' + _dairy.installments[j].balanceAmount + '</td>';
                            } else {
                                _innerBody += '        <td class="text-end px-0"><form class="align-items-center m-0 px-1 row"><div class="col-auto p-0"><input class="form-control form-control-sm" id="txtinstallment_' + _dairy.installments[j].id + '" style="width: 100px"  type="number" value="' + todayBalance + '"></div><div class="col-auto px-1"><input style="width: 50px" class="btn btn-sm btn-primary" type="button" value="Pay" onclick="onclickPayInstallment(this,' + _dairy.installments[j].id + ',' + numb + ')"/></div></form></td>';

                            }


                            //_innerBody += '        <td class="text-end"><form class="row align-items-center "><div class="col-auto p-2"><input class="form-control form-control-sm" style="width: 100px"  type="text" value=""></div><div class="col-auto p-0"><input style="width: 50px" class="btn btn-sm btn-primary" type="button" value="Pay" onclick="onClickSearch(this)"/></div></form></td>';
                            //'+_dairy.installments[j].balanceAmount+'
                            _innerBody += '        <td class="text-center">' + (_dairy.installments[j].isClosed == true ? 'Closed' : (_dairy.installments[j].balanceAmount == 0 ? "Paid" : 'Unpaid')) + '</td>';
                            _innerBody += '    </tr>';
                        }
                        _innerBody += '    </body>';
                        _innerBody += '</table>';
                    }
                } else {
                    swal({
                        title: "Dairy not found, Please try another dairy number.",
                        icon: "info",
                    });
                }
                $('#txtsearchdairynumber').val('');
                $('#divDairyDetail').html(_innerBody);
                detailDairyModel.show();
            }
        }
    });
};
onclickPayInstallment =(e,id,dairyNumber)=>{
    // alert($('#txtinstallment_'+id).val());

    var paylod = {
        id: id,
        amount: parseInt($('#txtinstallment_'+id).val()),
        isClosed: false
    }

    $.ajax({
        type: 'POST',
        url: "/dairy/installment/pay",
        data:paylod,
        success: function (res) {
            if(res.success)
            {
                swal({title: "Installment paid succesfully.",icon: "success",});
                bindDairyByNumber(dairyNumber);
            }
        }
    });
};

//     bindCustomers = ()=>{
//     $.ajax({
//         type: 'GET',
//         url: "/dairy/customers",
//         success: function (res) {
//             $('#divDairyDetail').html('');
//             if(res.success)
//             {
//                 _customers = [];
//                 $('#ddlcustomers').html('');
//                 $('#ddlcustomers').append("<option value='0'>New Customer</option>")
//                 for(let i = 0; i < res.data.length; i++) {
//                     _customers.push({customerId:res.data[i].id, customerName: res.data[i].name});
//                     $('#ddlcustomers').append("<option value='"+res.data[i].id+"'>"+res.data[i].name+"</option>")
//                 }
//             }
//         }
//     });
// };
//     bindAgents = ()=>{
//     $.ajax({
//         type: 'GET',
//         url: "/dairy/agents",
//         success: function (res) {
//             $('#divDairyDetail').html('');
//             if(res.success)
//             {
//                 _agents = [];
//                 $('#ddlagents').html('');
//                 for(let i = 0; i < res.data.length; i++) {
//                     _agents.push({agentId:res.data[i].id, agentName: res.data[i].name});
//                     $('#ddlagents').append("<option value='"+res.data[i].id+"'>"+res.data[i].name+"</option>")
//                 }
//             }
//         }
//     });
// };
//     bindHasDairyPaidAmount = ()=>{
//     $.ajax({
//         type: 'GET',
//         url: "/dairy/refdairies",
//         success: function (res) {
//             $('#divDairyDetail').html('');
//             if(res.success)
//             {
//                 _dairiesHadbalance = [];
//                 $('#ddlrefdairies').html('');
//                 $('#ddlrefdairies').append("<option value='0'>Cash</option>")
//                 for(let i = 0; i < res.data.length; i++) {
//                     _dairiesHadbalance.push({dairyNumber:res.data[i].id,dairyNumber:res.data[i].dairyNumber, paidAmount: res.data[i].paidAmount});
//                     $('#ddlrefdairies').append("<option value='"+res.data[i].dairyNumber+"'>"+res.data[i].dairyNumber+"</option>")
//                 }
//             }
//         }
//     });
// };
//     bindDairyNewNumber = ()=>{
//     $.ajax({
//         type: 'GET',
//         url: "/dairy/getdairynumber",
//         success: function (res) {
//             if(res.success)
//             {
//                 $('#txtdairynumber').val( res.data+1);
//                 return res.data;
//             }
//         }
//     });
// };
//     onclickPayInstallment =(e,id,dairyNumber)=>{
//     // alert($('#txtinstallment_'+id).val());
//
//     var paylod = {
//     id: id,
//     amount: parseInt($('#txtinstallment_'+id).val()),
//     isClosed: false
// }
//
//     $.ajax({
//     type: 'POST',
//     url: "/dairy/installment/pay",
//     data:paylod,
//     success: function (res) {
//     if(res.success)
// {
//     swal({title: "Installment paid succesfully.",icon: "success",});
//     bindDairyByNumber(dairyNumber);
// }
// }
// });
// }
