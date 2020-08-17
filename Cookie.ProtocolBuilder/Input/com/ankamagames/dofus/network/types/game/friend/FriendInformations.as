package com.ankamagames.dofus.network.types.game.friend
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FriendInformations extends AbstractContactInformations implements INetworkType
   {
      
      public static const protocolId:uint = 78;
       
      
      public var playerState:uint = 99;
      
      public var lastConnection:uint = 0;
      
      public var achievementPoints:int = 0;
      
      public function FriendInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 78;
      }
      
      public function initFriendInformations(param1:uint = 0, param2:String = "", param3:uint = 99, param4:uint = 0, param5:int = 0) : FriendInformations
      {
         super.initAbstractContactInformations(param1,param2);
         this.playerState = param3;
         this.lastConnection = param4;
         this.achievementPoints = param5;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.playerState = 99;
         this.lastConnection = 0;
         this.achievementPoints = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FriendInformations(param1);
      }
      
      public function serializeAs_FriendInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractContactInformations(param1);
         param1.writeByte(this.playerState);
         if(this.lastConnection < 0)
         {
            throw new Error("Forbidden value (" + this.lastConnection + ") on element lastConnection.");
         }
         param1.writeVarShort(this.lastConnection);
         param1.writeInt(this.achievementPoints);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FriendInformations(param1);
      }
      
      public function deserializeAs_FriendInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._playerStateFunc(param1);
         this._lastConnectionFunc(param1);
         this._achievementPointsFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FriendInformations(param1);
      }
      
      public function deserializeAsyncAs_FriendInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._playerStateFunc);
         param1.addChild(this._lastConnectionFunc);
         param1.addChild(this._achievementPointsFunc);
      }
      
      private function _playerStateFunc(param1:ICustomDataInput) : void
      {
         this.playerState = param1.readByte();
         if(this.playerState < 0)
         {
            throw new Error("Forbidden value (" + this.playerState + ") on element of FriendInformations.playerState.");
         }
      }
      
      private function _lastConnectionFunc(param1:ICustomDataInput) : void
      {
         this.lastConnection = param1.readVarUhShort();
         if(this.lastConnection < 0)
         {
            throw new Error("Forbidden value (" + this.lastConnection + ") on element of FriendInformations.lastConnection.");
         }
      }
      
      private function _achievementPointsFunc(param1:ICustomDataInput) : void
      {
         this.achievementPoints = param1.readInt();
      }
   }
}
