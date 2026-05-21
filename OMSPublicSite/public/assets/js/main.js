function defaultRadioSelected(){
    document.getElementById("weekly").checked=true;
    isWeeklySelected();
}
defaultRadioSelected();

/*DISABLED FORM FIELDS*/

function radioSelected(e){
    let value=e.target.id;

    if(value==="weekly"){
        isWeeklySelected();
        }
    else if(value==="monthly"){
        isMonthlySelected();
        }
    else if(value==="specific-date"){
        isSpecificDateSelected();
        }
}



function isWeeklySelected(){
    document.getElementById("start-date").disabled=true;
    document.getElementById("end-date").disabled=true;
    document.getElementById("specific-date-select").disabled=true;
    document.getElementById("table-submit-btn").disabled=true;
    
    let tableEl=document.querySelector("table");
    tableEl.classList.add("disabled");
    
    let addTableRowEl= document.querySelector("#table-submit-btn");
    addTableRowEl.classList.add("disabled");

    let tabsEl =document.querySelector("ul.weekly-tabs");
    tabsEl.classList.remove("disabled");
}

function isMonthlySelected(){
    document.getElementById("start-date").disabled=false;
    document.getElementById("end-date").disabled=false;
    
    document.getElementById("specific-date-select").disabled=true;
    document.getElementById("table-submit-btn").disabled=true;
    
    let tableEl=document.querySelector("table");
    tableEl.classList.add("disabled");
    
    let tabsEl =document.querySelector("ul.weekly-tabs");
    tabsEl.classList.add("disabled");
    
    let addTableRowEl= document.querySelector("#table-submit-btn");
    addTableRowEl.classList.add("disabled");

}


function isSpecificDateSelected(){
    document.getElementById("start-date").disabled=true;
    document.getElementById("end-date").disabled=true;
    
    document.getElementById("specific-date-select").disabled=false;
    document.getElementById("table-submit-btn").disabled=false;
    
    let tabsEl =document.querySelector("ul.weekly-tabs");
    tabsEl.classList.add("disabled");
    
    let tableEl=document.querySelector("table");
    tableEl.classList.remove("disabled");

    let addTableRowEl= document.querySelector("#table-submit-btn");
    addTableRowEl.classList.remove("disabled");
}


/*END FOR DISABLED FORM FIELDS*/


// MULTIPLE SELECT WEEKLY DAYS

document.querySelectorAll('.days-tabs').forEach(item => {
    item.addEventListener('click', event => {
        var element = event.target;
        element.classList.toggle("active-tab");
    })
})
// END MULTIPLE SELECT WEEKLY DAYS



// DATA TABLE

let plusBtn= document.getElementById("table-submit-btn");
plusBtn.addEventListener("click",dataTable);

let specificDateEl=document.getElementById("specific-date-select");
let tableBodyEl=document.querySelector("tbody");
let deleteBtn;


function dataTable(){
    
    if(specificDateEl.value !== ""){
    let sNo=2;
    let date=specificDateEl.value;
 
    
    
    let tableRowEl= document.createElement("tr");
    let snoTdEl= document.createElement("td");	
    let dateTdEl= document.createElement("td");	
    let btnTdEl= document.createElement("td");
    let deleteBtnEl=document.createElement("button");

   
  

    deleteBtnEl.setAttribute("id","remove-table-row");
    deleteBtnEl.innerText="X"
    deleteBtnEl.setAttribute("onclick", "removeTableRow(event)");
    deleteBtnEl.setAttribute("class","deleteBtn");

    
    snoTdEl.innerText=sNo;
    dateTdEl.innerText=date;
    btnTdEl.appendChild(deleteBtnEl);	
    
    tableRowEl.appendChild(snoTdEl);
    tableRowEl.appendChild(dateTdEl);
    tableRowEl.appendChild(btnTdEl);

    deleteBtn=deleteBtnEl;
  

    
    
    // tableBodyEl.children.appendChild(tableRowEl)
    tableBodyEl.appendChild(tableRowEl)
    
    }
    
    }

    function removeTableRow(e){
        var del=deleteBtn.parentElement.parentElement;
        del.remove();
        }
   

    // END DATA TABLE