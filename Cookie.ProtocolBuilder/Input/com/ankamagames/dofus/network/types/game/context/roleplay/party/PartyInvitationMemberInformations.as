package com.ankamagames.dofus.network.types.game.context.roleplay.party
{
   import com.ankamagames.dofus.network.types.game.character.choice.CharacterBaseInformations;
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.companion.PartyCompanionBaseInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PartyInvitationMemberInformations extends CharacterBaseInformations implements INetworkType
   {
      
      public static const protocolId:uint = 376;
       
      
      public var worldX:int = 0;
      
      public var worldY:int = 0;
      
      public var mapId:int = 0;
      
      public var subAreaId:uint = 0;
      
      public var companions:Vector.<PartyCompanionBaseInformations>;
      
      private var _companionstree:FuncTree;
      
      public function PartyInvitationMemberInformations()
      {
         this.companions = new Vector.<PartyCompanionBaseInformations>();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 376;
      }
      
      public function initPartyInvitationMemberInformations(param1:Number = 0, param2:String = "", param3:uint = 0, param4:EntityLook = null, param5:int = 0, param6:Boolean = false, param7:int = 0, param8:int = 0, param9:int = 0, param10:uint = 0, param11:Vector.<PartyCompanionBaseInformations> = null) : PartyInvitationMemberInformations
      {
         super.initCharacterBaseInformations(param1,param2,param3,param4,param5,param6);
         this.worldX = param7;
         this.worldY = param8;
         this.mapId = param9;
         this.subAreaId = param10;
         this.companions = param11;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.worldX = 0;
         this.worldY = 0;
         this.mapId = 0;
         this.subAreaId = 0;
         this.companions = new Vector.<PartyCompanionBaseInformations>();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PartyInvitationMemberInformations(param1);
      }
      
      public function serializeAs_PartyInvitationMemberInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_CharacterBaseInformations(param1);
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element worldX.");
         }
         param1.writeShort(this.worldX);
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element worldY.");
         }
         param1.writeShort(this.worldY);
         param1.writeInt(this.mapId);
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element subAreaId.");
         }
         param1.writeVarShort(this.subAreaId);
         param1.writeShort(this.companions.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.companions.length)
         {
            (this.companions[_loc2_] as PartyCompanionBaseInformations).serializeAs_PartyCompanionBaseInformations(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyInvitationMemberInformations(param1);
      }
      
      public function deserializeAs_PartyInvitationMemberInformations(param1:ICustomDataInput) : void
      {
         var _loc4_:PartyCompanionBaseInformations = null;
         super.deserialize(param1);
         this._worldXFunc(param1);
         this._worldYFunc(param1);
         this._mapIdFunc(param1);
         this._subAreaIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new PartyCompanionBaseInformations();
            _loc4_.deserialize(param1);
            this.companions.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyInvitationMemberInformations(param1);
      }
      
      public function deserializeAsyncAs_PartyInvitationMemberInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._worldXFunc);
         param1.addChild(this._worldYFunc);
         param1.addChild(this._mapIdFunc);
         param1.addChild(this._subAreaIdFunc);
         this._companionstree = param1.addChild(this._companionstreeFunc);
      }
      
      private function _worldXFunc(param1:ICustomDataInput) : void
      {
         this.worldX = param1.readShort();
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element of PartyInvitationMemberInformations.worldX.");
         }
      }
      
      private function _worldYFunc(param1:ICustomDataInput) : void
      {
         this.worldY = param1.readShort();
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element of PartyInvitationMemberInformations.worldY.");
         }
      }
      
      private function _mapIdFunc(param1:ICustomDataInput) : void
      {
         this.mapId = param1.readInt();
      }
      
      private function _subAreaIdFunc(param1:ICustomDataInput) : void
      {
         this.subAreaId = param1.readVarUhShort();
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of PartyInvitationMemberInformations.subAreaId.");
         }
      }
      
      private function _companionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._companionstree.addChild(this._companionsFunc);
            _loc3_++;
         }
      }
      
      private function _companionsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:PartyCompanionBaseInformations = new PartyCompanionBaseInformations();
         _loc2_.deserialize(param1);
         this.companions.push(_loc2_);
      }
   }
}
