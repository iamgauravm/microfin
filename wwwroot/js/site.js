
var accountType = {
    Cash: 1,
    Investors: 2,
    Customers: 3,
    Agents: 4,
    Expenses: 5,
    Diaries: 6
};
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


var detailDiaryModel = new bootstrap.Modal(document.getElementById('detailDiaryModel'), {
    backdrop: 'static',
    keyboard: false
});





onClickSearch = (e) => {
    
    if ($('#txtsearchDiarynumber').val() != '') {

        bindDiaryDetail($('#txtsearchDiarynumber').val());        
    } else {
        swal({title: "Please enter Diary number!", icon: "warning",});
        return;
    }
}

bindDiaryByNumber = (numb) => {
    $.ajax({
        type: 'GET',
        url: "/Diary/getbynumber/" + numb,
        success: function (res) {
            $('#divDiaryDetail').html('');
            if (res.success) {
                _Diary = res.data;
                var _innerBody = "";
                if (_Diary != null) {
                    _innerBody += '<h4>#' + _Diary.DiaryNumber + '</h4>';
                    _innerBody += '<table class="table table-borderless">';
                    _innerBody += '    <tr>';
                    _innerBody += '        <td style="width: 110px">Name : </td>';
                    _innerBody += '        <td colspan="3">' + _Diary.customerName + ' S/o ' + _Diary.customerFatherName + ' [' + _Diary.customerMobile + ']</td>';
                    _innerBody += '    </tr>';
                    _innerBody += '    <tr>';
                    _innerBody += '        <td>Start : </td>';
                    _innerBody += '        <td>' + moment(_Diary.startDate).format('DD-MM-YYYY') + '</td>';
                    _innerBody += '        <td>End : </td>';
                    _innerBody += '        <td>' + moment(_Diary.endDate).format('DD-MM-YYYY') + '</td>';
                    _innerBody += '    </tr>';
                    _innerBody += '    <tr>';
                    _innerBody += '        <td>Loan : </td>';
                    _innerBody += '        <td>' + _Diary.loanAmount + '</td>';
                    _innerBody += '        <td>Total : </td>';
                    _innerBody += '        <td>' + _Diary.totalAmount + '</td>';
                    _innerBody += '    </tr>';
                    _innerBody += '    <tr>';
                    _innerBody += '        <td>Balance : </td>';
                    _innerBody += '        <td>' + _Diary.totalBalanceAmount + '</td>';
                    _innerBody += '        <td>Status : </td>';
                    _innerBody += '        <td>' + (_Diary.isCompleted == true ? 'Complete' : 'Incomplete') + '</td>';
                    _innerBody += '    </tr>';
                    _innerBody += '</table>';

                    if (_Diary.installments?.length > 0) {
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
                        for (let j = 0; j < _Diary.installments.length; j++) {
                            var _className = "";

                            if (moment().format('DD-MM-YYYY') == moment(_Diary.installments[j].installmentDate).format('DD-MM-YYYY')) {
                                _className = 'bg-info';
                            } else if (moment() > moment(_Diary.installments[j].installmentDate)) {
                                _className = 'bg-past-dt';
                            }
                            todayBalance += _Diary.installments[j].balanceAmount;


                            _innerBody += '    <tr class="' + _className + '">';
                            _innerBody += '        <td class="text-center">' + _Diary.installments[j].installmentNumber + '</td>';
                            _innerBody += '        <td class="text-center">' + moment(_Diary.installments[j].installmentDate).format('DD-MM-YYYY') + '</td>';
                            // _innerBody += '        <td class="text-end">'+_Diary.installments[j].installmentAmount+'</td>';


                            if (_Diary.installments[j].balanceAmount == 0 || moment().format('DD-MM-YYYY') != moment(_Diary.installments[j].installmentDate).format('DD-MM-YYYY')) {
                                _innerBody += '        <td class="text-end px-1">' + _Diary.installments[j].balanceAmount + '</td>';
                            } else {
                                _innerBody += '        <td class="text-end px-0"><form class="align-items-center m-0 px-1 row"><div class="col-auto p-0"><input class="form-control form-control-sm" id="txtinstallment_' + _Diary.installments[j].id + '" style="width: 100px"  type="number" value="' + todayBalance + '"></div><div class="col-auto px-1"><input style="width: 50px" class="btn btn-sm btn-primary" type="button" value="Pay" onclick="onclickPayInstallment(this,' + _Diary.installments[j].id + ',' + numb + ')"/></div></form></td>';

                            }


                            //_innerBody += '        <td class="text-end"><form class="row align-items-center "><div class="col-auto p-2"><input class="form-control form-control-sm" style="width: 100px"  type="text" value=""></div><div class="col-auto p-0"><input style="width: 50px" class="btn btn-sm btn-primary" type="button" value="Pay" onclick="onClickSearch(this)"/></div></form></td>';
                            //'+_Diary.installments[j].balanceAmount+'
                            _innerBody += '        <td class="text-center">' + (_Diary.installments[j].isClosed == true ? 'Closed' : (_Diary.installments[j].balanceAmount == 0 ? "Paid" : 'Unpaid')) + '</td>';
                            _innerBody += '    </tr>';
                        }
                        _innerBody += '    </body>';
                        _innerBody += '</table>';
                    }
                } else {
                    swal({
                        title: "Diary not found, Please try another Diary number.",
                        icon: "info",
                    });
                }
                $('#txtsearchDiarynumber').val('');
                $('#divDiaryDetail').html(_innerBody);
                detailDiaryModel.show();
            }
        }
    });
};

bindDiaryDetail = (numb) => {
    $.ajax({
        type: 'GET',
        url: "/admin/Diarydetail/" + numb,
        success: function (res) {            
            $('#divDiaryDetail').html(res);
            $('#txtsearchDiarynumber').val('');
            detailDiaryModel.show();
        }
    });
};

onClickShowDiaryPayment =(num)=>{
    var detailDiaryPaymentModel = new bootstrap.Modal(document.getElementById('detailDiaryPaymentModel'), {
        backdrop: 'static',
        keyboard: false
    });
    detailDiaryPaymentModel.show();
}
onClickDiaryPaymentSave = () =>{
    
    var paylod = {
        diaryId: parseInt($('#txtDiaryPayment_DiaryId').val()),
        paymentDate: $('#txtDiaryPayment_Date').val(),
        paymentAmount: parseInt($('#txtDiaryPayment_Amount').val()),
        paymentLateAmount: parseInt($('#txtDiaryPayment_LateAmount').val()),
        paymentTotal: parseInt($('#txtDiaryPayment_Total').val()),
        paymentMode: $('#rdDiaryPayment_PaymentMode').val(),
        closedDiary: $('#chkDiaryPayment_Closed').prop('checked')        
    };
    console.log(paylod);

    $.ajax({
        type: 'POST',
        url: "/diary/payment",
        data:paylod,
        success: function (res) {
            if(res.success)
            {
                swal({title: "Installment paid succesfully.",icon: "success",});
                bindDiaryByNumber(DiaryNumber);
            }
        }
    });
    $('#detailDiaryPaymentModel').modal('hide');
}

onclickPayInstallment =(e,id,DiaryNumber)=>{
    // alert($('#txtinstallment_'+id).val());

    var paylod = {
        id: id,
        amount: parseInt($('#txtinstallment_'+id).val()),
        isClosed: false
    }

    $.ajax({
        type: 'POST',
        url: "/Diary/installment/pay",
        data:paylod,
        success: function (res) {
            if(res.success)
            {
                swal({title: "Installment paid succesfully.",icon: "success",});
                bindDiaryByNumber(DiaryNumber);
            }
        }
    });
};

//     bindCustomers = ()=>{
//     $.ajax({
//         type: 'GET',
//         url: "/Diary/customers",
//         success: function (res) {
//             $('#divDiaryDetail').html('');
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
//         url: "/Diary/agents",
//         success: function (res) {
//             $('#divDiaryDetail').html('');
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
//     bindHasDiaryPaidAmount = ()=>{
//     $.ajax({
//         type: 'GET',
//         url: "/Diary/refdiaries",
//         success: function (res) {
//             $('#divDiaryDetail').html('');
//             if(res.success)
//             {
//                 _diariesHadbalance = [];
//                 $('#ddlrefdiaries').html('');
//                 $('#ddlrefdiaries').append("<option value='0'>Cash</option>")
//                 for(let i = 0; i < res.data.length; i++) {
//                     _diariesHadbalance.push({DiaryNumber:res.data[i].id,DiaryNumber:res.data[i].DiaryNumber, paidAmount: res.data[i].paidAmount});
//                     $('#ddlrefdiaries').append("<option value='"+res.data[i].DiaryNumber+"'>"+res.data[i].DiaryNumber+"</option>")
//                 }
//             }
//         }
//     });
// };
//     bindDiaryNewNumber = ()=>{
//     $.ajax({
//         type: 'GET',
//         url: "/Diary/getDiarynumber",
//         success: function (res) {
//             if(res.success)
//             {
//                 $('#txtDiarynumber').val( res.data+1);
//                 return res.data;
//             }
//         }
//     });
// };
//     onclickPayInstallment =(e,id,DiaryNumber)=>{
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
//     url: "/Diary/installment/pay",
//     data:paylod,
//     success: function (res) {
//     if(res.success)
// {
//     swal({title: "Installment paid succesfully.",icon: "success",});
//     bindDiaryByNumber(DiaryNumber);
// }
// }
// });
// }
