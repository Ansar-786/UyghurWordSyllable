<?php  

  function bughum($input,$type = 0){ 
                /* replace spaial chars */ 
                $input = str_replace(array('ـ','','  ','*','%','#'),'',$input); 
                $input = str_replace(array("\r","\t","\n",'. ','، ',':','»','«','›','‹','<','>','(',')','?','؟ ','! '),' ',$input); 
                /* uyghur alphabet char */ 
                /* suzuq tawush */ 
                $st = array('ا','ە','ې','ى','و','ۇ','ۆ','ۈ'); 
                /* suzuq tawush bash shekli */ 
                $kst = array('ئا','ئە','ئې','ئى','ئو','ئۇ','ئۆ','ئۈ'); 
                /* uzuk tawush */ 
                $uz = array('ب','پ','ت','ج','چ','خ','گ','ك','ل','م','ن','ز','ژ','ر','س','ش','د','ي','ف','ھ','غ','ق','ۋ','ڭ'); 
                /* suzuq tawush aldi keynige belge selish 0.0*/ 
                foreach($st as $key => $value){ 
                        $input = str_replace($value,'0'. $value. '0',$input); 
                } 
                /* uzuk tawush aldi keynige belge selish 1.1 */ 
                foreach($uz as $key => $value){ 
                        $input = str_replace($value,'1'. $value. '1',$input); 
                } 
                /* bughumgha ayriydighan orunni suzup chiqish */ 
                foreach($uz as $key => $value){ 
                        $input = str_replace('01'. $value. '11',$value. '11',$input); 
                } 
                $input = str_replace('00','',$input); 
                $input = str_replace('10','',$input); 
                /* bughumgha ayrilidighan jaygha belge selish + */ 
                $input = str_replace('01','+',$input); 
                $input = str_replace('11','+',$input); 
                $input = str_replace('1','+',$input); 
                /* artuq belilerni suziwitish */ 
                $input = str_replace('0','',$input); 
                foreach($uz as $key => $value){ 
                        $input = str_replace('+'. $value. '+',$value. '+',$input); 
                } 
                foreach($kst as $key => $value){ 
                        $input = str_replace($value,'+'. $value,$input); 
                } 
                $input = str_replace('~+','','~'. $input); 
                $input = str_replace('+~','',$input. '~'); 
                $input = str_replace('++','+',$input); 
                $input = str_replace(' +',' ',$input); 
                $input = str_replace('+ ',' ',$input); 
                $input = str_replace('  ',' ',$input); 
                $input = str_replace('~','',$input); 
                $input = str_replace(' - ','-',$input); 
                /* tekistni sozlerge bolush */ 
                $input = explode(" ",$input); 
                /* quruq sozlerni tazilash */ 
                foreach($input as $key => $value){ 
                        if(empty($value)) unset($input["$key"]); 
                } 
                /* ahirida $input ning elminitlirini '+' arqiliq bOleklerge bolsek bughumlargha erishkili bolidu */ 
                foreach($input as $key => $value){ 
                        $output["$key"] = explode('+',$value); 
                } 
                /* outputs */ 
                if($type == 1) $return = $output; 
                elseif($type == 2) $return = count($output); 
                elseif($type == 3) $return = array('count'=>count($output),'output'=>$output,'input'=>$input); 
                else $return = $input; 
                /* return */ 
                return $return; 
                /* end */ 
        }
		
?>