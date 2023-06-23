function setCharacterSkinColor(data) {
    DesactiveAllColorsPickedSkin();
    var d = JSON.parse(data["data"]);

    if (d.color == 0.1) {
        $("#pikc1").addClass("active");
    }

    if (d.color == 0.2) {
        $("#pikc2").addClass("active");
    }

    if (d.color == 0.3) {
        $("#pikc3").addClass("active");
    }
    if (d.color == 0.4) {
        $("#pikc4").addClass("active");
    }
    if (d.color == 0.5) {
        $("#pikc5").addClass("active");
    }
    if (d.color == 0.6) {
        $("#pikc6").addClass("active");
    }
    if (d.color == 0.7) {
        $("#pikc7").addClass("active");
    }
    if (d.color == 0.8) {
        $("#pikc8").addClass("active");
    }
    if (d.color == 0.9) {
        $("#pikc9").addClass("active");
    }
    if (d.color == 1.0) {
        $("#pikc10").addClass("active");
    }
}

function setCharacterEyeColor(data) {
    DesactiveAllColorsPickedEye();
    var d = JSON.parse(data["data"]);

    if (d.color == 0) {
        $("#eyeblack").addClass("active");
    }

    if (d.color == 1) {
        $("#eyeverylightbluegreen").addClass("active");
    }

    if (d.color == 2) {
        $("#eyedarkblue").addClass("active");
    }

    if (d.color == 3) {
        $("#eyebrown").addClass("active");
    }

    if (d.color == 4) {
        $("#eyedarkerbrown").addClass("active");
    }
    if (d.color == 5) {
        $("#eyeblue").addClass("active");
    }
    if (d.color == 6) {
        $("#eyelightblue").addClass("active");
    }
    if (d.color == 7) {
        $("#eyepink").addClass("active");
    }

    if (d.color == 8) {
        $("#eyeyellow").addClass("active");
    }
    if (d.color == 9) {
        $("#eyepurple").addClass("active");
    }
    if (d.color == 10) {
        $("#eyedarkgreen").addClass("active");
    }
    if (d.color == 11) {
        $("#eyelightbrown").addClass("active");
    }
    if (d.color == 12) {
        $("#eyedark").addClass("actiçve");
    }

    if (d.color == 13) {
        $("#eyegray").addClass("active");
    }
    if (d.color == 14) {
        $("#eyefox").addClass("active");
    }

}


$(function () {
    window.addEventListener('message', function (event) {
        var item = event.data;
        if (item.showIn == true) {

            fetch(`https://player/get_player_skin_color`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify({
                })
            }).then(resp => resp.json()).then(success => setCharacterSkinColor(success));

            fetch(`https://player/get_player_eye_color`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify({
                })
            }).then(resp => resp.json()).then(success => setCharacterEyeColor(success));

            fetch(`https://player/get_player_head_info`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify({
                })
            }).then(resp => resp.json()).then(success => setCharacterHeadInfo(success));



            document.getElementsByClassName("main")[0].style.display = "block";
        }
        else {
            document.getElementsByClassName("main")[0].style.display = "none";
        }
    });


    $('#genderselectorM').on('click', function () {
        $('#genderselectorM').css("color", "rgba(255, 0, 0, 1)");
        $('#genderselectorF').css("color", "#fff");

        fetch(`https://player/change_character_gender`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            }, body: JSON.stringify({
                gender: "M"
            })
        }).then()
            .catch(err => {
            });
        fetch(`https://player/get_player_head_info`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
            })
        }).then(resp => resp.json()).then(success => setCharacterHeadInfo(success));

    });

    $('#genderselectorF').on('click', function () {

        $('#genderselectorF').css("color", "rgba(255, 0, 0, 1)");
        $('#genderselectorM').css("color", "#fff");

        fetch(`https://player/change_character_gender`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            }, body: JSON.stringify({
                gender: "F",
            })
        }).then()
            .catch(err => {
            });
        fetch(`https://player/get_player_head_info`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
            })
        }).then(resp => resp.json()).then(success => setCharacterHeadInfo(success));
    });




});

function DesactiveAllColorsPickedSkin() {
    $("#pikc1").removeClass("active");
    $("#pikc2").removeClass("active");
    $("#pikc3").removeClass("active");
    $("#pikc4").removeClass("active");
    $("#pikc5").removeClass("active");
    $("#pikc6").removeClass("active");
    $("#pikc7").removeClass("active");
    $("#pikc8").removeClass("active");
    $("#pikc9").removeClass("active");
    $("#pikc10").removeClass("active");
}

function DesactiveAllColorsPickedEye() {
    $("#eyeblack").removeClass("active");
    $("#eyeverylightbluegreen").removeClass("active");
    $("#eyedarkblue").removeClass("active");
    $("#eyebrown").removeClass("active");
    $("#eyedarkerbrown").removeClass("active");
    $("#eyeblue").removeClass("active");
    $("#eyelightblue").removeClass("active");
    $("#eyepink").removeClass("active");
    $("#eyeyellow").removeClass("active");
    $("#eyepurple").removeClass("active");
    $("#eyedarkgreen").removeClass("active");
    $("#eyelightbrown").removeClass("active");
    $("#eyedark").removeClass("active");
    $("#eyegray").removeClass("active");
    $("#eyefox").removeClass("active");
}


function setCharacterHeadInfo(data) {
    var d = JSON.parse(data["data"]);
    $("#NoseWidthThinWide").val(d.noseWidthThinWide)
    $("#NosePeakUpDown").val(d.nosePeakUpDown)
    $("#NoseLengthLongShort").val(d.noseLengthLongShort)
    $("#NoseBoneCurvenessCrookedCurved").val(d.newoseBoneCurvenessCrookedCurved)
    $("#NoseTipUpDown").val(d.noseTipUpDown)
    $("#NoseBoneTwistLeftRight").val(d.noseBoneTwistLeftRight)
    $("#EyebrowUpDown").val(d.eyebrowUpDown)
    $("#EyebrowInOut").val(d.eyebrowInOut)
    $("#CheekBonesUpDown").val(d.cheekBonesUpDown)
    $("#CheekSidewaysBoneSizeInOut").val(d.cheekSidewaysBoneSizeInOut)
    $("#CheekBonesWidthPuffedGaunt").val(d.cheekBonesWidthPuffedGaunt)
    $("#EyeOpeningBothWideSquinted").val(d.eyeOpeningBothWideSquinted)
    $("#LipThicknessBothFatThin").val(d.lipThicknessBothFatThin)
    $("#JawBoneWidthNarrowWide").val(d.jawBoneWidthNarrowWide)
    $("#JawBoneShapeRoundSquare").val(d.jawBoneShapeRoundSquare)
    $("#ChinBoneUpDown").val(d.chinBoneUpDown)
    $("#ChinBoneLengthInOut").val(d.chinBoneLengthInOut)
    $("#ChinBoneShapePointedSquare").val(d.chinBoneShapePointedSquare)
    $("#ChinHoleChinBum").val(d.chinHoleChinBum)
    $("#NeckThicknessThinThick").val(d.neckThicknessThinThick)
}

function ChangeColorSkin(color, clsass) {
    DesactiveAllColorsPickedSkin();
    $("#" + clsass).addClass("active");

    fetch(`https://player/change_ped_color`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        }, body: JSON.stringify({
            color: color,
        })
    }).then()
        .catch(err => {
        });

    fetch(`https://player/get_player_head_info`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        },
        body: JSON.stringify({
        })
    }).then(resp => resp.json()).then(success => setCharacterHeadInfo(success));

    fetch(`https://player/get_player_eye_color`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        },
        body: JSON.stringify({
        })
    }).then(resp => resp.json()).then(success => setCharacterEyeColor(success));

}

function UpdateCharacterEyeColor(event, type, id) {
    DesactiveAllColorsPickedEye()
    $("#" + id).addClass("active");
    fetch(`https://player/set_character_eye`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        }, body: JSON.stringify({
            value: type,
        })
    }).then()
        .catch(err => {
        });
}




function UpdateCharacterFace(event, type) {
    fetch(`https://player/` + type, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        }, body: JSON.stringify({
            value: event.value,
        })
    }).then()
        .catch(err => {
        });
}
