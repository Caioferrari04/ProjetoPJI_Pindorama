var slideIndex2 = 1
showSlides2(slideIndex2)

function plus(n2) {
    showSlides2(slideIndex2 += n2)
}

function currentSlide2(n2) {
    showSlides2(slideIndex2 = n2)
}

function showSlides2(n2) {
    var slides2 = document.getElementsByClassName("mySlides2")
    if (slides2 != null) {
        if (n2 > slides2.length) { slideIndex2 = 1 }
        if (n2 < 1) { slideIndex2 = slides2.length }
        for (var i = 0; i < slides2.length; i++) {
            slides2[i].style.display = "none"
        }
            slides2[slideIndex2 - 1].style.display = "flex"
    }
}