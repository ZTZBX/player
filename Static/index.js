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

function setHearColor(data) {
    DesactiveAllHairColors();
    var d = JSON.parse(data["data"]);
    $("#hightlight").val(d.hightlight);
    $("#" + d.color + "ColorHair").addClass("active");
}


function setEyesBrows(data) {
    DesactiveAllEyeBrows();
    var d = JSON.parse(data["data"]);
    $("#" + d.eyesbrow + "EyesBrows").addClass("activehair");
    $("#" + d.eyesbrow + "EyesBrowsF").addClass("activehair");
}


function setPlayerGender(gender)
{
    if (gender == "M")
    {   
        $("#HairMale").css("display", "block")
        $("#HairFamale").css("display", "none")
        $("#BrowsMale").css("display", "block")
        $("#BrowsFamale").css("display", "none")

        $("#BeardMaleMes").css("display", "block")
        $("#BeardMale").css("display", "block")
        
    }
    else 
    {
        $("#HairFamale").css("display", "block")
        $("#HairMale").css("display", "none")
        $("#BrowsMale").css("display", "none")
        $("#BrowsFamale").css("display", "block")

        $("#BeardMaleMes").css("display", "none")
        $("#BeardMale").css("display", "none")
    }
}

function setPlayerGenderApi(data) {
    DesactiveAllEyeBrows();
    var d = JSON.parse(data["data"]);
    setPlayerGender(d.gender);
}

$(function () {
    window.addEventListener('message', function (event) {
        var item = event.data;
        if (item.showIn == true) {
            
            fetch(`https://player/get_player_gender`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify({
                })
            }).then(resp => resp.json()).then(success => setPlayerGenderApi(success));


            fetch(`https://player/get_eyebrows`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify({
                })
            }).then(resp => resp.json()).then(success => setEyesBrows(success));

            fetch(`https://player/get_player_hear_color`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify({
                })
            }).then(resp => resp.json()).then(success => setHearColor(success));

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

            fetch(`https://player/get_hair`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify({
                })
            }).then(resp => resp.json()).then(success => setHair(success));



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

        setPlayerGender("M");

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

        setPlayerGender("F");
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

function setHair(data) {
    DesactiveAllHairs();
    var d = JSON.parse(data["data"]);
    $("#" + d.hair.replace(".png", "")).addClass("activehair");
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

    fetch(`https://player/get_hair`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        },
        body: JSON.stringify({
        })
    }).then(resp => resp.json()).then(success => setHair(success));

    fetch(`https://player/get_player_hear_color`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        },
        body: JSON.stringify({
        })
    }).then(resp => resp.json()).then(success => setHearColor(success));


    fetch(`https://player/get_eyebrows`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        },
        body: JSON.stringify({
        })
    }).then(resp => resp.json()).then(success => setEyesBrows(success));

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

function UpdateCharacterHair(event, type) {
    DesactiveAllHairs();
    $("#" + type.replace(".png", "")).addClass("activehair");
    fetch(`https://player/set_character_hair`, {
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


function UpdateEyesBrows(event, type) {
    DesactiveAllEyeBrows();
    $("#" + type + "EyesBrows").addClass("activehair");
    $("#" + type + "EyesBrowsF").addClass("activehair");
    fetch(`https://player/set_eyesbrows`, {
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

function DesactiveAllHairColors() {
    $("#0ColorHair").removeClass("active");
    $("#1ColorHair").removeClass("active");
    $("#2ColorHair").removeClass("active");
    $("#3ColorHair").removeClass("active");
    $("#4ColorHair").removeClass("active");
    $("#5ColorHair").removeClass("active");
    $("#6ColorHair").removeClass("active");
    $("#7ColorHair").removeClass("active");
    $("#8ColorHair").removeClass("active");
    $("#9ColorHair").removeClass("active");
    $("#10ColorHair").removeClass("active");
    $("#11ColorHair").removeClass("active");
    $("#12ColorHair").removeClass("active");
    $("#13ColorHair").removeClass("active");
    $("#14ColorHair").removeClass("active");
    $("#15ColorHair").removeClass("active");
    $("#16ColorHair").removeClass("active");
    $("#17ColorHair").removeClass("active");
    $("#18ColorHair").removeClass("active");
    $("#19ColorHair").removeClass("active");
    $("#20ColorHair").removeClass("active");
    $("#21ColorHair").removeClass("active");
    $("#22ColorHair").removeClass("active");
    $("#23ColorHair").removeClass("active");
    $("#24ColorHair").removeClass("active");
    $("#25ColorHair").removeClass("active");
    $("#26ColorHair").removeClass("active");
    $("#27ColorHair").removeClass("active");
    $("#28ColorHair").removeClass("active");
    $("#29ColorHair").removeClass("active");
    $("#30ColorHair").removeClass("active");
    $("#31ColorHair").removeClass("active");
    $("#32ColorHair").removeClass("active");
    $("#33ColorHair").removeClass("active");
    $("#34ColorHair").removeClass("active");
    $("#35ColorHair").removeClass("active");
    $("#36ColorHair").removeClass("active");
    $("#37ColorHair").removeClass("active");
    $("#38ColorHair").removeClass("active");
    $("#39ColorHair").removeClass("active");
    $("#40ColorHair").removeClass("active");
    $("#41ColorHair").removeClass("active");
    $("#42ColorHair").removeClass("active");
    $("#43ColorHair").removeClass("active");
    $("#44ColorHair").removeClass("active");
    $("#45ColorHair").removeClass("active");
    $("#46ColorHair").removeClass("active");
    $("#47ColorHair").removeClass("active");
    $("#48ColorHair").removeClass("active");
    $("#49ColorHair").removeClass("active");
    $("#50ColorHair").removeClass("active");
    $("#51ColorHair").removeClass("active");
    $("#52ColorHair").removeClass("active");
    $("#53ColorHair").removeClass("active");
    $("#54ColorHair").removeClass("active");
    $("#55ColorHair").removeClass("active");
    $("#56ColorHair").removeClass("active");
    $("#57ColorHair").removeClass("active");
    $("#58ColorHair").removeClass("active");
    $("#59ColorHair").removeClass("active");
    $("#60ColorHair").removeClass("active");
    $("#61ColorHair").removeClass("active");
    $("#62ColorHair").removeClass("active");
    $("#63ColorHair").removeClass("active");


}

function UpdateCharacterHairColor(event, type) {
    DesactiveAllHairColors();
    $("#" + type).addClass("active");

    fetch(`https://player/set_player_hair_color`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        }, body: JSON.stringify({
            value: type.replace("ColorHair", ""),
        })
    }).then()
        .catch(err => {
        });
}

function DesactiveAllHairs() {
    $("#Bold").removeClass("activehair");
    $("#Afro").removeClass("activehair");
    $("#BunHair").removeClass("activehair");
    $("#Curly").removeClass("activehair");
    $("#Dreds").removeClass("activehair");
    $("#MaxPayne").removeClass("activehair");
    $("#Scruffy").removeClass("activehair");

    $("#BoldF").removeClass("activehair");
    $("#AdrienneFHair").removeClass("activehair");
    $("#JanetsFHair").removeClass("activehair");
    $("#EmilyFHair").removeClass("activehair");
    $("#BrazilianFHair").removeClass("activehair");
    $("#AliceFHair").removeClass("activehair");
    $("#GlamFHair").removeClass("activehair");
}

function DesactiveAllEyeBrows() {
    $("#0EyesBrows").removeClass("activehair");
    $("#1EyesBrows").removeClass("activehair");
    $("#2EyesBrows").removeClass("activehair");
    $("#3EyesBrows").removeClass("activehair");
    $("#4EyesBrows").removeClass("activehair");
    $("#5EyesBrows").removeClass("activehair");
    $("#6EyesBrows").removeClass("activehair");
    $("#7EyesBrows").removeClass("activehair");

    $("#0EyesBrowsF").removeClass("activehair");
    $("#1EyesBrowsF").removeClass("activehair");
    $("#2EyesBrowsF").removeClass("activehair");
    $("#3EyesBrowsF").removeClass("activehair");
    $("#4EyesBrowsF").removeClass("activehair");
    $("#5EyesBrowsF").removeClass("activehair");
    $("#6EyesBrowsF").removeClass("activehair");
    $("#7EyesBrowsF").removeClass("activehair");
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

function UpdateHairColorHightlight(event) {
    fetch(`https://player/update_player_hightlight`, {
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