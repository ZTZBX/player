$(function () {
    window.addEventListener('message', function (event) {
        var item = event.data;
        if (item.showIn == true) {

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
