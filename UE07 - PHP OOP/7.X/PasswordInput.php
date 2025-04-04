<?php
require_once("BaseInput.php");
class PasswordInput extends BaseInput
{
    public function renderInput(){
        echo "<input type='password' name='".$this->name."' value='".$this->value."' label>";
    }

    public function render()
    {
        echo "<label>".$this->label."</label>";
        echo "<input type='password' name='".$this->name."' value='".$this->value."' label>";
    }
}