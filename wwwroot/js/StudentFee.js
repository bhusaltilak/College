let rowIndex = document.querySelectorAll("#feeBody tr").length;

function addRow() {
    const tbody = document.getElementById("feeBody");
    const row = document.createElement("tr");

    row.innerHTML = `
        <input type="hidden" name="Fees[${rowIndex}].Id" value="0" />
        <td><input name="Fees[${rowIndex}].StudentName" class="form-control" /></td>
        <td><input name="Fees[${rowIndex}].Grade" class="form-control" /></td>
        <td><input name="Fees[${rowIndex}].Month" class="form-control" /></td>
        <td><input name="Fees[${rowIndex}].Amount" class="form-control" type="number" /></td>
        <td>
            <select name="Fees[${rowIndex}].AmountStatus" class="form-control">
                <option value="Unpaid">Unpaid</option>
                <option value="Paid">Paid</option>
            </select>
        </td>
        <td><button type="button" class="btn btn-danger" onclick="removeRow(this)">Remove</button></td>
    `;

    tbody.appendChild(row);
    rowIndex++;
}

function removeRow(button) {
    button.closest("tr").remove();
}
