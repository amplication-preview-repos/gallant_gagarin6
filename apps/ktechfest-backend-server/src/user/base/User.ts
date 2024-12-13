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
import { Application } from "../../application/base/Application";
import {
  ValidateNested,
  IsOptional,
  IsDate,
  IsString,
  MaxLength,
  IsEnum,
} from "class-validator";
import { Type } from "class-transformer";
import { Job } from "../../job/base/Job";
import { Rating } from "../../rating/base/Rating";
import { StaffAgency } from "../../staffAgency/base/StaffAgency";
import { EnumUserRole } from "./EnumUserRole";
import { IsJSONValue } from "../../validators";
import { GraphQLJSON } from "graphql-type-json";
import { JsonValue } from "type-fest";
import { Skill } from "../../skill/base/Skill";
import { Staff } from "../../staff/base/Staff";
import { Wallet } from "../../wallet/base/Wallet";

@ObjectType()
class User {
  @ApiProperty({
    required: false,
    type: () => [Application],
  })
  @ValidateNested()
  @Type(() => Application)
  @IsOptional()
  applications?: Array<Application>;

  @ApiProperty({
    required: false,
    type: () => [Job],
  })
  @ValidateNested()
  @Type(() => Job)
  @IsOptional()
  assignedJobs?: Array<Job>;

  @ApiProperty({
    required: true,
  })
  @IsDate()
  @Type(() => Date)
  @Field(() => Date)
  createdAt!: Date;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  email!: string | null;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @MaxLength(256)
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  firstName!: string | null;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @Field(() => String)
  id!: string;

  @ApiProperty({
    required: false,
    type: () => [Job],
  })
  @ValidateNested()
  @Type(() => Job)
  @IsOptional()
  jobs?: Array<Job>;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @MaxLength(256)
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  lastName!: string | null;

  @ApiProperty({
    required: false,
    type: () => [Rating],
  })
  @ValidateNested()
  @Type(() => Rating)
  @IsOptional()
  myRatings?: Array<Rating>;

  @ApiProperty({
    required: false,
    type: () => StaffAgency,
  })
  @ValidateNested()
  @Type(() => StaffAgency)
  @IsOptional()
  myStaffAgency?: StaffAgency | null;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @MaxLength(1000)
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  name!: string | null;

  @ApiProperty({
    required: false,
    type: () => Rating,
  })
  @ValidateNested()
  @Type(() => Rating)
  @IsOptional()
  ratings?: Rating | null;

  @ApiProperty({
    required: true,
    enum: EnumUserRole,
  })
  @IsEnum(EnumUserRole)
  @Field(() => EnumUserRole, {
    nullable: true,
  })
  role?: "Individual" | "Staff" | "StaffAgency";

  @ApiProperty({
    required: true,
  })
  @IsJSONValue()
  @Field(() => GraphQLJSON)
  roles!: JsonValue;

  @ApiProperty({
    required: false,
    type: () => [Skill],
  })
  @ValidateNested()
  @Type(() => Skill)
  @IsOptional()
  skills?: Array<Skill>;

  @ApiProperty({
    required: false,
    type: () => Staff,
  })
  @ValidateNested()
  @Type(() => Staff)
  @IsOptional()
  staff?: Staff | null;

  @ApiProperty({
    required: true,
  })
  @IsDate()
  @Type(() => Date)
  @Field(() => Date)
  updatedAt!: Date;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @Field(() => String)
  username!: string;

  @ApiProperty({
    required: false,
    type: () => Wallet,
  })
  @ValidateNested()
  @Type(() => Wallet)
  @IsOptional()
  wallet?: Wallet | null;
}

export { User as User };