import React, { useState } from 'react'
import { CKEditor } from '@ckeditor/ckeditor5-react';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
export default function Editor() {
  const [value, setValue]= useState("");
  function handleOnchange(e, editor){
      const data= editor.getData();
      setValue(data);
      
  }
  return (
    <><div>Editor</div>
    <CKEditor
      editor={ClassicEditor}
      onChange={handleOnchange}
    />
    </>
  )
}
