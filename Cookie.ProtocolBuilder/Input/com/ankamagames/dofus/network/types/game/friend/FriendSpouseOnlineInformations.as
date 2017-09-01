package com.ankamagames.dofus.network.types.game.friend
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.GuildInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FriendSpouseOnlineInformations extends FriendSpouseInformations implements INetworkType
   {
      
      public static const protocolId:uint = 93;
       
      
      public var mapId:uint = 0;
      
      public var subAreaId:uint = 0;
      
      public var inFight:Boolean = false;
      
      public var followSpouse:Boolean = false;
      
      public function FriendSpouseOnlineInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 93;
      }
      
      public function initFriendSpouseOnlineInformations(param1:uint = 0, param2:Number = 0, param3:String = "", param4:uint = 0, param5:int = 0, param6:int = 0, param7:EntityLook = null, param8:GuildInformations = null, param9:int = 0, param10:uint = 0, param11:uint = 0, param12:Boolean = false, param13:Boolean = false) : FriendSpouseOnlineInformations
      {
         super.initFriendSpouseInformations(param1,param2,param3,param4,param5,param6,param7,param8,param9);
         this.mapId = param10;
         this.subAreaId = param11;
         this.inFight = param12;
         this.followSpouse = param13;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.mapId = 0;
         this.subAreaId = 0;
         this.inFight = false;
         this.followSpouse = false;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FriendSpouseOnlineInformations(param1);
      }
      
      public function serializeAs_FriendSpouseOnlineInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_FriendSpouseInformations(param1);
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.inFight);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.followSpouse);
         param1.writeByte(_loc2_);
         if(this.mapId < 0)
         {
            throw new Error("Forbidden value (" + this.mapId + ") on element mapId.");
         }
         param1.writeInt(this.mapId);
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element subAreaId.");
         }
         param1.writeVarShort(this.subAreaId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FriendSpouseOnlineInformations(param1);
      }
      
      public function deserializeAs_FriendSpouseOnlineInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.deserializeByteBoxes(param1);
         this._mapIdFunc(param1);
         this._subAreaIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FriendSpouseOnlineInformations(param1);
      }
      
      public function deserializeAsyncAs_FriendSpouseOnlineInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._mapIdFunc);
         param1.addChild(this._subAreaIdFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.inFight = BooleanByteWrapper.getFlag(_loc2_,0);
         this.followSpouse = BooleanByteWrapper.getFlag(_loc2_,1);
      }
      
      private function _mapIdFunc(param1:ICustomDataInput) : void
      {
         this.mapId = param1.readInt();
         if(this.mapId < 0)
         {
            throw new Error("Forbidden value (" + this.mapId + ") on element of FriendSpouseOnlineInformations.mapId.");
         }
      }
      
      private function _subAreaIdFunc(param1:ICustomDataInput) : void
      {
         this.subAreaId = param1.readVarUhShort();
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of FriendSpouseOnlineInformations.subAreaId.");
         }
      }
   }
}
