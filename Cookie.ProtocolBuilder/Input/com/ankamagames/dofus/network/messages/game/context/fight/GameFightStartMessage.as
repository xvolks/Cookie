package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.dofus.network.types.game.idol.Idol;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightStartMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 712;
       
      
      private var _isInitialized:Boolean = false;
      
      public var idols:Vector.<Idol>;
      
      private var _idolstree:FuncTree;
      
      public function GameFightStartMessage()
      {
         this.idols = new Vector.<Idol>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 712;
      }
      
      public function initGameFightStartMessage(param1:Vector.<Idol> = null) : GameFightStartMessage
      {
         this.idols = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.idols = new Vector.<Idol>();
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
         this.serializeAs_GameFightStartMessage(param1);
      }
      
      public function serializeAs_GameFightStartMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.idols.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.idols.length)
         {
            (this.idols[_loc2_] as Idol).serializeAs_Idol(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightStartMessage(param1);
      }
      
      public function deserializeAs_GameFightStartMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:Idol = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new Idol();
            _loc4_.deserialize(param1);
            this.idols.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightStartMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightStartMessage(param1:FuncTree) : void
      {
         this._idolstree = param1.addChild(this._idolstreeFunc);
      }
      
      private function _idolstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._idolstree.addChild(this._idolsFunc);
            _loc3_++;
         }
      }
      
      private function _idolsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Idol = new Idol();
         _loc2_.deserialize(param1);
         this.idols.push(_loc2_);
      }
   }
}
