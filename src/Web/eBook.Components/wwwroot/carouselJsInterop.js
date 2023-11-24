function moveToSlide(slideIndex) {
    // Move the carousel to a specific slide
    $('#carouselExampleCaptions').carousel(slideIndex);
}

function nextSlide() {
    // Move to the next slide
    $('#carouselExampleCaptions').carousel('next');
}

function previousSlide() {
    // Move to the previous slide
    $('#carouselExampleCaptions').carousel('prev');
}