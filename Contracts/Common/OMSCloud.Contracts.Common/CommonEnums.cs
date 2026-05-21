using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Common
{

	public enum ResponseStatus
	{
		Success,
		Failure,
		Error
	}

	public enum StatusMessage
	{
		[Description("None")]
		None,
		[Description("Successful")]
		Successful,
		[Description("Failure")]
		Failure,
		[Description("Error")]
		Error,
		[Description("User Not Found")]
		UserNotFound,
		[Description("Login Name Already Exists")]
		LoginNameAlreadyExists,
		[Description("Unexpected Error Occured")]
		UnexpectedErrorOccured,
		[Description("Entity Not Found")]
		EntityNotFound,
		[Description("Invalid Username Or Password")]
		InvalidUsernameOrPassword,
		[Description("Invalid Current Password. Enter correct Password")]
		InvalidCurrentPassword,

		[Description("User already logged-in")]
		UserAlreadyLoggedIn,
		[Description("User already logged-in")]
		UserNotLoggedIn,

		[Description("Login Name Available")]
		LoginNameAvailable,
		[Description("No Action Signature Found")]
		NoActionSignatureFound,
		[Description("Access Denied")]
		AccessDenied,
		[Description("AMT Access Denied")]
		AMTAccessDenied,
		[Description("AMT Network Access Failure")]
		AMTNetworkAccessFailure,
		[Description("ABN Already Exists")]
		ABNAlreadyExists,
		[Description("ACN Already Exists")]
		ACNAlreadyExists,
		[Description("GST Already Exists")]
		GSTAlreadyExists,
		[Description("TFN Already Exists")]
		TFNAlreadyExists,
		[Description("Name Already Exists")]
		NameAlreadyExists,
		[Description("User Login Already Exists")]
		UserLoginAlreadyExists,
		[Description("Entity Type Of \"Group\" Not Found")]
		EntityTypeOfGroupNotFound,
		[Description("Unable To Add")]
		UnableToAdd,
		[Description("Unable To Delete")]
		UnableToDelete,
		[Description("Record Added Successfully")]
		RecordAddedSuccessfully,
		[Description("Record Deleted Successfully")]
		RecordDeletedSuccessfully,
		[Description("Group with the same name already exists")]
		UserGroupAlreadyExists,
		[Description("The model proided is either Empty or Invalid")]
		EmptyOrInvalidModel,
		[Description("Unable to update the specified record(s)")]
		UnableToUpdate,
		[Description("Role with the same name already exists")]
		RoleAlreadyExists,
		[Description("Event is not assigned to an AMT Operation.")]
		EventNotAssignedInAMTComponent,
	}

}
