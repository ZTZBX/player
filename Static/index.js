$(function () {
    window.addEventListener('message', function (event) {
        var item = event.data;
        if (item.showIn == true) {
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
    });




});

function DesactiveAllColorsPickedSkin()
{
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

function ChangeColorSkin(color, clsass) {
    DesactiveAllColorsPickedSkin();
    $("#"+clsass).addClass( "active" );

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

}