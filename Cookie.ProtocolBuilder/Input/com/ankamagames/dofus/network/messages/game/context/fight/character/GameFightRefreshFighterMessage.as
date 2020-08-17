package com.ankamagames.dofus.network.messages.game.context.fight.character
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.GameContextActorInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightRefreshFighterMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6309;
       
      
      private var _isInitialized:Boolean = false;
      
      public var informations:GameContextActorInformations;
      
      private var _informationstree:FuncTree;
      
      public function GameFightRefreshFighterMessage()
      {
         this.informations = new GameContextActorInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6309;
      }
      
      public function initGameFightRefreshFighterMessage(param1:GameContextActorInformations = null) : GameFightRefreshFighterMessage
      {
         this.informations = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.informations = new GameContextActorInformations();
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
         this.serializeAs_GameFightRefreshFighterMessage(param1);
      }
      
      public function serializeAs_GameFightRefreshFighterMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.informations.getTypeId());
         this.informations.serialize(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightRefreshFighterMessage(param1);
      }
      
      public function deserializeAs_GameFightRefreshFighterMessage(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.informations = ProtocolTypeManager.getInstance(GameContextActorInformations,_loc2_);
         this.informations.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightRefreshFighterMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightRefreshFighterMessage(param1:FuncTree) : void
      {
         this._informationstree = param1.addChild(this._informationstreeFunc);
      }
      
      private function _informationstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.informations = ProtocolTypeManager.getInstance(GameContextActorInformations,_loc2_);
         this.informations.deserializeAsync(this._informationstree);
      }
   }
}
