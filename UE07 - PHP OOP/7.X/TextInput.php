<?php
require_once("BaseInput.php");
class TextInput extends BaseInput
{
    public function renderInput(){
        echo "<input type='text' name='".$this->name."' value='".$this->value."' label>";
    }

    public function render()
    {
        echo "<label>".$this->label."</label>";
        echo "<input type='text' name='".$this->name."' value='".$this->value."' label>";
    }
}