<?php
require_once("HtmlElement.php");
class Form extends HtmlElement
{

    public $method;
    private array $elements = [];
    public $action;

    function __construct($action = "post", $method = "") {
        $this->action = $action;
        $this->method = $method;
    }

    public function render()
    {
        echo "<form method='".$this->method."' action='".$this->action."'>";
        foreach ($this->elements as $element) {
            if($element instanceof HtmlElement){
                $element->render();
            }
        }
        echo "</form>";
    }

    public function addElement(HtmlElement $element)
    {
        $this->elements[] = $element;
    }
}