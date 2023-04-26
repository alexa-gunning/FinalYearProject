export class Attendance {

    //client 
    clientId:number
    name:string
    surname:string
    phoneNumber:string
    birthDate:string
    emailAddress:string
    genderId:number
    // userId:number

    //workshopslot
    workshopId: number
    workshopTypeId: number
    workshopVenueId: number
    hostId: number
    price: number
    workshopDate: string
    hostName: string
    venueName: string
    typeDescription: string
    
    //Attendance table
    attendanceStatusId: number
    attendanceStatusName: string

    //Booking 

    bookingId: number
    bookingDate: Date

  }