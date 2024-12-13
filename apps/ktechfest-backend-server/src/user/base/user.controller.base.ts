/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { isRecordNotFoundError } from "../../prisma.util";
import * as errors from "../../errors";
import { Request } from "express";
import { plainToClass } from "class-transformer";
import { ApiNestedQuery } from "../../decorators/api-nested-query.decorator";
import { UserService } from "../user.service";
import { UserCreateInput } from "./UserCreateInput";
import { User } from "./User";
import { UserFindManyArgs } from "./UserFindManyArgs";
import { UserWhereUniqueInput } from "./UserWhereUniqueInput";
import { UserUpdateInput } from "./UserUpdateInput";
import { ApplicationFindManyArgs } from "../../application/base/ApplicationFindManyArgs";
import { Application } from "../../application/base/Application";
import { ApplicationWhereUniqueInput } from "../../application/base/ApplicationWhereUniqueInput";
import { JobFindManyArgs } from "../../job/base/JobFindManyArgs";
import { Job } from "../../job/base/Job";
import { JobWhereUniqueInput } from "../../job/base/JobWhereUniqueInput";
import { RatingFindManyArgs } from "../../rating/base/RatingFindManyArgs";
import { Rating } from "../../rating/base/Rating";
import { RatingWhereUniqueInput } from "../../rating/base/RatingWhereUniqueInput";
import { SkillFindManyArgs } from "../../skill/base/SkillFindManyArgs";
import { Skill } from "../../skill/base/Skill";
import { SkillWhereUniqueInput } from "../../skill/base/SkillWhereUniqueInput";

export class UserControllerBase {
  constructor(protected readonly service: UserService) {}
  @common.Post()
  @swagger.ApiCreatedResponse({ type: User })
  @swagger.ApiBody({
    type: UserCreateInput,
  })
  async createUser(@common.Body() data: UserCreateInput): Promise<User> {
    return await this.service.createUser({
      data: {
        ...data,

        myStaffAgency: data.myStaffAgency
          ? {
              connect: data.myStaffAgency,
            }
          : undefined,

        ratings: data.ratings
          ? {
              connect: data.ratings,
            }
          : undefined,

        staff: data.staff
          ? {
              connect: data.staff,
            }
          : undefined,

        wallet: data.wallet
          ? {
              connect: data.wallet,
            }
          : undefined,
      },
      select: {
        createdAt: true,
        email: true,
        firstName: true,
        id: true,
        lastName: true,

        myStaffAgency: {
          select: {
            id: true,
          },
        },

        name: true,

        ratings: {
          select: {
            id: true,
          },
        },

        role: true,
        roles: true,

        staff: {
          select: {
            id: true,
          },
        },

        updatedAt: true,
        username: true,

        wallet: {
          select: {
            id: true,
          },
        },
      },
    });
  }

  @common.Get()
  @swagger.ApiOkResponse({ type: [User] })
  @ApiNestedQuery(UserFindManyArgs)
  async users(@common.Req() request: Request): Promise<User[]> {
    const args = plainToClass(UserFindManyArgs, request.query);
    return this.service.users({
      ...args,
      select: {
        createdAt: true,
        email: true,
        firstName: true,
        id: true,
        lastName: true,

        myStaffAgency: {
          select: {
            id: true,
          },
        },

        name: true,

        ratings: {
          select: {
            id: true,
          },
        },

        role: true,
        roles: true,

        staff: {
          select: {
            id: true,
          },
        },

        updatedAt: true,
        username: true,

        wallet: {
          select: {
            id: true,
          },
        },
      },
    });
  }

  @common.Get("/:id")
  @swagger.ApiOkResponse({ type: User })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async user(
    @common.Param() params: UserWhereUniqueInput
  ): Promise<User | null> {
    const result = await this.service.user({
      where: params,
      select: {
        createdAt: true,
        email: true,
        firstName: true,
        id: true,
        lastName: true,

        myStaffAgency: {
          select: {
            id: true,
          },
        },

        name: true,

        ratings: {
          select: {
            id: true,
          },
        },

        role: true,
        roles: true,

        staff: {
          select: {
            id: true,
          },
        },

        updatedAt: true,
        username: true,

        wallet: {
          select: {
            id: true,
          },
        },
      },
    });
    if (result === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return result;
  }

  @common.Patch("/:id")
  @swagger.ApiOkResponse({ type: User })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  @swagger.ApiBody({
    type: UserUpdateInput,
  })
  async updateUser(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() data: UserUpdateInput
  ): Promise<User | null> {
    try {
      return await this.service.updateUser({
        where: params,
        data: {
          ...data,

          myStaffAgency: data.myStaffAgency
            ? {
                connect: data.myStaffAgency,
              }
            : undefined,

          ratings: data.ratings
            ? {
                connect: data.ratings,
              }
            : undefined,

          staff: data.staff
            ? {
                connect: data.staff,
              }
            : undefined,

          wallet: data.wallet
            ? {
                connect: data.wallet,
              }
            : undefined,
        },
        select: {
          createdAt: true,
          email: true,
          firstName: true,
          id: true,
          lastName: true,

          myStaffAgency: {
            select: {
              id: true,
            },
          },

          name: true,

          ratings: {
            select: {
              id: true,
            },
          },

          role: true,
          roles: true,

          staff: {
            select: {
              id: true,
            },
          },

          updatedAt: true,
          username: true,

          wallet: {
            select: {
              id: true,
            },
          },
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new errors.NotFoundException(
          `No resource was found for ${JSON.stringify(params)}`
        );
      }
      throw error;
    }
  }

  @common.Delete("/:id")
  @swagger.ApiOkResponse({ type: User })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async deleteUser(
    @common.Param() params: UserWhereUniqueInput
  ): Promise<User | null> {
    try {
      return await this.service.deleteUser({
        where: params,
        select: {
          createdAt: true,
          email: true,
          firstName: true,
          id: true,
          lastName: true,

          myStaffAgency: {
            select: {
              id: true,
            },
          },

          name: true,

          ratings: {
            select: {
              id: true,
            },
          },

          role: true,
          roles: true,

          staff: {
            select: {
              id: true,
            },
          },

          updatedAt: true,
          username: true,

          wallet: {
            select: {
              id: true,
            },
          },
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new errors.NotFoundException(
          `No resource was found for ${JSON.stringify(params)}`
        );
      }
      throw error;
    }
  }

  @common.Get("/:id/applications")
  @ApiNestedQuery(ApplicationFindManyArgs)
  async findApplications(
    @common.Req() request: Request,
    @common.Param() params: UserWhereUniqueInput
  ): Promise<Application[]> {
    const query = plainToClass(ApplicationFindManyArgs, request.query);
    const results = await this.service.findApplications(params.id, {
      ...query,
      select: {
        createdAt: true,
        id: true,

        job: {
          select: {
            id: true,
          },
        },

        staffAgency: {
          select: {
            id: true,
          },
        },

        status: true,
        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
    if (results === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return results;
  }

  @common.Post("/:id/applications")
  async connectApplications(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: ApplicationWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      applications: {
        connect: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Patch("/:id/applications")
  async updateApplications(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: ApplicationWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      applications: {
        set: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Delete("/:id/applications")
  async disconnectApplications(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: ApplicationWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      applications: {
        disconnect: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Get("/:id/assignedJobs")
  @ApiNestedQuery(JobFindManyArgs)
  async findAssignedJobs(
    @common.Req() request: Request,
    @common.Param() params: UserWhereUniqueInput
  ): Promise<Job[]> {
    const query = plainToClass(JobFindManyArgs, request.query);
    const results = await this.service.findAssignedJobs(params.id, {
      ...query,
      select: {
        assignedTo: {
          select: {
            id: true,
          },
        },

        associatedAgency: {
          select: {
            id: true,
          },
        },

        availability: true,
        completed: true,
        createdAt: true,
        cv: true,
        description: true,
        duration: true,
        id: true,
        isAcceptedByAgency: true,
        isPaid: true,
        payRate: true,

        payments: {
          select: {
            id: true,
          },
        },

        status: true,
        title: true,
        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
    if (results === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return results;
  }

  @common.Post("/:id/assignedJobs")
  async connectAssignedJobs(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: JobWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      assignedJobs: {
        connect: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Patch("/:id/assignedJobs")
  async updateAssignedJobs(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: JobWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      assignedJobs: {
        set: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Delete("/:id/assignedJobs")
  async disconnectAssignedJobs(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: JobWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      assignedJobs: {
        disconnect: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Get("/:id/jobs")
  @ApiNestedQuery(JobFindManyArgs)
  async findJobs(
    @common.Req() request: Request,
    @common.Param() params: UserWhereUniqueInput
  ): Promise<Job[]> {
    const query = plainToClass(JobFindManyArgs, request.query);
    const results = await this.service.findJobs(params.id, {
      ...query,
      select: {
        assignedTo: {
          select: {
            id: true,
          },
        },

        associatedAgency: {
          select: {
            id: true,
          },
        },

        availability: true,
        completed: true,
        createdAt: true,
        cv: true,
        description: true,
        duration: true,
        id: true,
        isAcceptedByAgency: true,
        isPaid: true,
        payRate: true,

        payments: {
          select: {
            id: true,
          },
        },

        status: true,
        title: true,
        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
    if (results === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return results;
  }

  @common.Post("/:id/jobs")
  async connectJobs(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: JobWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      jobs: {
        connect: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Patch("/:id/jobs")
  async updateJobs(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: JobWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      jobs: {
        set: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Delete("/:id/jobs")
  async disconnectJobs(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: JobWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      jobs: {
        disconnect: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Get("/:id/myRatings")
  @ApiNestedQuery(RatingFindManyArgs)
  async findMyRatings(
    @common.Req() request: Request,
    @common.Param() params: UserWhereUniqueInput
  ): Promise<Rating[]> {
    const query = plainToClass(RatingFindManyArgs, request.query);
    const results = await this.service.findMyRatings(params.id, {
      ...query,
      select: {
        comment: true,
        createdAt: true,

        entityRated: {
          select: {
            id: true,
          },
        },

        id: true,

        job: {
          select: {
            id: true,
          },
        },

        ratedBy: {
          select: {
            id: true,
          },
        },

        ratingValue: true,
        updatedAt: true,
      },
    });
    if (results === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return results;
  }

  @common.Post("/:id/myRatings")
  async connectMyRatings(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: RatingWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      myRatings: {
        connect: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Patch("/:id/myRatings")
  async updateMyRatings(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: RatingWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      myRatings: {
        set: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Delete("/:id/myRatings")
  async disconnectMyRatings(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: RatingWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      myRatings: {
        disconnect: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Get("/:id/skills")
  @ApiNestedQuery(SkillFindManyArgs)
  async findSkills(
    @common.Req() request: Request,
    @common.Param() params: UserWhereUniqueInput
  ): Promise<Skill[]> {
    const query = plainToClass(SkillFindManyArgs, request.query);
    const results = await this.service.findSkills(params.id, {
      ...query,
      select: {
        createdAt: true,
        description: true,
        id: true,

        jobs: {
          select: {
            id: true,
          },
        },

        name: true,

        staff: {
          select: {
            id: true,
          },
        },

        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
    if (results === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return results;
  }

  @common.Post("/:id/skills")
  async connectSkills(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: SkillWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      skills: {
        connect: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Patch("/:id/skills")
  async updateSkills(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: SkillWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      skills: {
        set: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Delete("/:id/skills")
  async disconnectSkills(
    @common.Param() params: UserWhereUniqueInput,
    @common.Body() body: SkillWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      skills: {
        disconnect: body,
      },
    };
    await this.service.updateUser({
      where: params,
      data,
      select: { id: true },
    });
  }
}