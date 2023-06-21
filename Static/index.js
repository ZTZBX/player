$(function() {
    window.addEventListener('message', function(event) { 
        var item = event.data;
        if (item.showIn == true) {
            document.getElementsByClassName("main")[0].style.display = "block";
        } 
        else 
        {
            document.getElementsByClassName("main")[0].style.display = "none";
        }
    });
});