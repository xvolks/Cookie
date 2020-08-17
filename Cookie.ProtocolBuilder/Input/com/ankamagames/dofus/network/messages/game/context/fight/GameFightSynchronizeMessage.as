package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.fight.GameFightFighterInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightSynchronizeMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5921;
       
      
      private var _isInitialized:Boolean = false;
      
      public var fighters:Vector.<GameFightFighterInformations>;
      
      private var _fighterstree:FuncTree;
      
      public function GameFightSynchronizeMessage()
      {
         this.fighters = new Vector.<GameFightFighterInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5921;
      }
      
      public function initGameFightSynchronizeMessage(param1:Vector.<GameFightFighterInformations> = null) : GameFightSynchronizeMessage
      {
         this.fighters = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.fighters = new Vector.<GameFightFighterInformations>();
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
         this.serializeAs_GameFightSynchronizeMessage(param1);
      }
      
      public function serializeAs_GameFightSynchronizeMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.fighters.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.fighters.length)
         {
            param1.writeShort((this.fighters[_loc2_] as GameFightFighterInformations).getTypeId());
            (this.fighters[_loc2_] as GameFightFighterInformations).serialize(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightSynchronizeMessage(param1);
      }
      
      public function deserializeAs_GameFightSynchronizeMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:GameFightFighterInformations = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(GameFightFighterInformations,_loc4_);
            _loc5_.deserialize(param1);
            this.fighters.push(_loc5_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightSynchronizeMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightSynchronizeMessage(param1:FuncTree) : void
      {
         this._fighterstree = param1.addChild(this._fighterstreeFunc);
      }
      
      private function _fighterstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._fighterstree.addChild(this._fightersFunc);
            _loc3_++;
         }
      }
      
      private function _fightersFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:GameFightFighterInformations = ProtocolTypeManager.getInstance(GameFightFighterInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.fighters.push(_loc3_);
      }
   }
}
