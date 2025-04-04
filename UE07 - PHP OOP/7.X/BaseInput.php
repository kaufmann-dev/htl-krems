<?php
require_once("HtmlElement.php");
abstract class BaseInput extends HtmlElement
{

    public $name;
    public $label;
    public $value;

    function __construct($name, $label, $value = "") {
        $this->name = $name;
        $this->label = $label;
        $this->value = $value;
    }

    abstract public function renderInput();
}