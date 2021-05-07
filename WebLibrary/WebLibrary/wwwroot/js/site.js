// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

<script type="text/javascript">
    function clock() {
                    var d = new Date();
                    var day = d.getDate();
                    var hrs = d.getHours();
                    var min = d.getMinutes();
                    var sec = d.getSeconds();

                    var mnt = new Array("января", "февраля", "марта", "апреля", "мая",
                        "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря");

                    if (day <= 9) day = "0" + day;
                    if (hrs <= 9) hrs = "0" + hrs;
                    if (min <= 9) min = "0" + min;
                    if (sec <= 9) sec = "0" + sec;

                    $("#time").html("Сейчас: " + hrs + ":" + min + ":" + sec + "&nbsp;&nbsp;&nbsp;" +
                        day + "-го " + mnt[d.getMonth()] + " " + d.getFullYear() + " г.");
                }
                setInterval("clock()", 1000);
</script>