package com.ankamagames.dofus.network.messages.game.guild
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GuildInformationsGeneralMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5557;
       
      
      private var _isInitialized:Boolean = false;
      
      public var abandonnedPaddock:Boolean = false;
      
      public var level:uint = 0;
      
      public var expLevelFloor:Number = 0;
      
      public var experience:Number = 0;
      
      public var expNextLevelFloor:Number = 0;
      
      public var creationDate:uint = 0;
      
      public var nbTotalMembers:uint = 0;
      
      public var nbConnectedMembers:uint = 0;
      
      public function GuildInformationsGeneralMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5557;
      }
      
      public function initGuildInformationsGeneralMessage(param1:Boolean = false, param2:uint = 0, param3:Number = 0, param4:Number = 0, param5:Number = 0, param6:uint = 0, param7:uint = 0, param8:uint = 0) : GuildInformationsGeneralMessage
      {
         this.abandonnedPaddock = param1;
         this.level = param2;
         this.expLevelFloor = param3;
         this.experience = param4;
         this.expNextLevelFloor = param5;
         this.creationDate = param6;
         this.nbTotalMembers = param7;
         this.nbConnectedMembers = param8;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.abandonnedPaddock = false;
         this.level = 0;
         this.expLevelFloor = 0;
         this.experience = 0;
         this.expNextLevelFloor = 0;
         this.creationDate = 0;
         this.nbTotalMembers = 0;
         this.nbConnectedMembers = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GuildInformationsGeneralMessage(param1);
      }
      
      public function serializeAs_GuildInformationsGeneralMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.abandonnedPaddock);
         if(this.level < 0 || this.level > 255)
         {
            throw new Error("Forbidden value (" + this.level + ") on element level.");
         }
         param1.writeByte(this.level);
         if(this.expLevelFloor < 0 || this.expLevelFloor > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.expLevelFloor + ") on element expLevelFloor.");
         }
         param1.writeVarLong(this.expLevelFloor);
         if(this.experience < 0 || this.experience > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experience + ") on element experience.");
         }
         param1.writeVarLong(this.experience);
         if(this.expNextLevelFloor < 0 || this.expNextLevelFloor > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.expNextLevelFloor + ") on element expNextLevelFloor.");
         }
         param1.writeVarLong(this.expNextLevelFloor);
         if(this.creationDate < 0)
         {
            throw new Error("Forbidden value (" + this.creationDate + ") on element creationDate.");
         }
         param1.writeInt(this.creationDate);
         if(this.nbTotalMembers < 0)
         {
            throw new Error("Forbidden value (" + this.nbTotalMembers + ") on element nbTotalMembers.");
         }
         param1.writeVarShort(this.nbTotalMembers);
         if(this.nbConnectedMembers < 0)
         {
            throw new Error("Forbidden value (" + this.nbConnectedMembers + ") on element nbConnectedMembers.");
         }
         param1.writeVarShort(this.nbConnectedMembers);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildInformationsGeneralMessage(param1);
      }
      
      public function deserializeAs_GuildInformationsGeneralMessage(param1:ICustomDataInput) : void
      {
         this._abandonnedPaddockFunc(param1);
         this._levelFunc(param1);
         this._expLevelFloorFunc(param1);
         this._experienceFunc(param1);
         this._expNextLevelFloorFunc(param1);
         this._creationDateFunc(param1);
         this._nbTotalMembersFunc(param1);
         this._nbConnectedMembersFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildInformationsGeneralMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildInformationsGeneralMessage(param1:FuncTree) : void
      {
         param1.addChild(this._abandonnedPaddockFunc);
         param1.addChild(this._levelFunc);
         param1.addChild(this._expLevelFloorFunc);
         param1.addChild(this._experienceFunc);
         param1.addChild(this._expNextLevelFloorFunc);
         param1.addChild(this._creationDateFunc);
         param1.addChild(this._nbTotalMembersFunc);
         param1.addChild(this._nbConnectedMembersFunc);
      }
      
      private function _abandonnedPaddockFunc(param1:ICustomDataInput) : void
      {
         this.abandonnedPaddock = param1.readBoolean();
      }
      
      private function _levelFunc(param1:ICustomDataInput) : void
      {
         this.level = param1.readUnsignedByte();
         if(this.level < 0 || this.level > 255)
         {
            throw new Error("Forbidden value (" + this.level + ") on element of GuildInformationsGeneralMessage.level.");
         }
      }
      
      private function _expLevelFloorFunc(param1:ICustomDataInput) : void
      {
         this.expLevelFloor = param1.readVarUhLong();
         if(this.expLevelFloor < 0 || this.expLevelFloor > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.expLevelFloor + ") on element of GuildInformationsGeneralMessage.expLevelFloor.");
         }
      }
      
      private function _experienceFunc(param1:ICustomDataInput) : void
      {
         this.experience = param1.readVarUhLong();
         if(this.experience < 0 || this.experience > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experience + ") on element of GuildInformationsGeneralMessage.experience.");
         }
      }
      
      private function _expNextLevelFloorFunc(param1:ICustomDataInput) : void
      {
         this.expNextLevelFloor = param1.readVarUhLong();
         if(this.expNextLevelFloor < 0 || this.expNextLevelFloor > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.expNextLevelFloor + ") on element of GuildInformationsGeneralMessage.expNextLevelFloor.");
         }
      }
      
      private function _creationDateFunc(param1:ICustomDataInput) : void
      {
         this.creationDate = param1.readInt();
         if(this.creationDate < 0)
         {
            throw new Error("Forbidden value (" + this.creationDate + ") on element of GuildInformationsGeneralMessage.creationDate.");
         }
      }
      
      private function _nbTotalMembersFunc(param1:ICustomDataInput) : void
      {
         this.nbTotalMembers = param1.readVarUhShort();
         if(this.nbTotalMembers < 0)
         {
            throw new Error("Forbidden value (" + this.nbTotalMembers + ") on element of GuildInformationsGeneralMessage.nbTotalMembers.");
         }
      }
      
      private function _nbConnectedMembersFunc(param1:ICustomDataInput) : void
      {
         this.nbConnectedMembers = param1.readVarUhShort();
         if(this.nbConnectedMembers < 0)
         {
            throw new Error("Forbidden value (" + this.nbConnectedMembers + ") on element of GuildInformationsGeneralMessage.nbConnectedMembers.");
         }
      }
   }
}
