const inputs = document.querySelectorAll('.input');

function focusFuncion(){
    let parent = this.parentNode.parentNode;
    parent.classList.add('focus');
}
inputs.forEach(input =>{
    input.addEventListener('focus', focusFuncion);
});