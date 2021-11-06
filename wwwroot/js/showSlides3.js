var slideIndex3 = 1
showSlides3(slideIndex3)

function plus2(n3) {
    showSlides3(slideIndex3 += n3)
}

function currentSlide(n3) {
    showSlides3(slideIndex3 = n3)
}

function showSlides3(n3) {
    var slides3 = document.getElementsByClassName("mySlides3")
    if (n3 > slides3.length) {slideIndex3 = 1}
    if (n3 < 1) {slideIndex3 = slides3.length}
    for (var i = 0; i < slides3.length; i++) {
        slides3[i].style.display = "none"
    }
    slides3[slideIndex3 - 1].style.display = "flex"
}
