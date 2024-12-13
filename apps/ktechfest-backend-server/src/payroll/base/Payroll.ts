/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { ObjectType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { StaffAgency } from "../../staffAgency/base/StaffAgency";
import {
  ValidateNested,
  IsOptional,
  IsDate,
  IsString,
  IsNumber,
  Min,
  Max,
  IsEnum,
} from "class-validator";
import { Type } from "class-transformer";
import { Staff } from "../../staff/base/Staff";
import { EnumPayrollStatus } from "./EnumPayrollStatus";

@ObjectType()
class Payroll {
  @ApiProperty({
    required: false,
    type: () => StaffAgency,
  })
  @ValidateNested()
  @Type(() => StaffAgency)
  @IsOptional()
  agency?: StaffAgency | null;

  @ApiProperty({
    required: true,
  })
  @IsDate()
  @Type(() => Date)
  @Field(() => Date)
  createdAt!: Date;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @Field(() => String)
  id!: string;

  @ApiProperty({
    required: false,
  })
  @IsDate()
  @Type(() => Date)
  @IsOptional()
  @Field(() => Date, {
    nullable: true,
  })
  payDate!: Date | null;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsNumber()
  @Min(-999999999)
  @Max(999999999)
  @IsOptional()
  @Field(() => Number, {
    nullable: true,
  })
  salaryAmount!: number | null;

  @ApiProperty({
    required: false,
    type: () => Staff,
  })
  @ValidateNested()
  @Type(() => Staff)
  @IsOptional()
  staff?: Staff | null;

  @ApiProperty({
    required: false,
    enum: EnumPayrollStatus,
  })
  @IsEnum(EnumPayrollStatus)
  @IsOptional()
  @Field(() => EnumPayrollStatus, {
    nullable: true,
  })
  status?: "Option1" | null;

  @ApiProperty({
    required: true,
  })
  @IsDate()
  @Type(() => Date)
  @Field(() => Date)
  updatedAt!: Date;
}

export { Payroll as Payroll };
