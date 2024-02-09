<?php
require_once("HtmlElement.php");
class Button extends HtmlElement
{
    public $text;

    function __construct($text, $attributes = "keinen plan") {
        $this->text = $text;
    }

    public function render()
    {
        echo "<button>".$this->text."</button>";
    }
}